using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private int playerRecievedDamage = 10;
    [SerializeField]
    private GameObject coin; 
	[SerializeField]
	private float speed;


    Transform tr;
    Rigidbody2D rb; 


	// Use this for initialization
	void Start () {

        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>(); 

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.right * speed * Input.GetAxisRaw ("Horizontal")); 

		if (Input.GetKeyDown (KeyCode.Space)) {
			if(rb.velocity.magnitude < 0.5 ){
				rb.AddForce (new Vector2 ((float)0, (float)300));
			}
		}


	}


    void OnTriggerEnter2D(Collider2D other)
    {

		switch (other.tag)
        {
            case "Enemy":

                Animator playerAnimator = other.gameObject.GetComponent<Animator>();

                if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack") ||
                   playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("jumpAtk"))
                {
                    Destroy(gameObject);
					Instantiate(coin, gameObject.transform);
                }
                else
                {
                    Player.get_Instance().setHealth(Player.get_Instance().getHealth() - playerRecievedDamage);
                }

                

                break;

            case "deathFloor":

                Player.get_Instance().setHealth(0);

                tr.position = new Vector2((float)-43.4, (float)-2.7) ;

                break;

            case "Coin":

                Player.get_Instance().collectCoin();

			Destroy(other.gameObject);

                break;

            case "Door":

                SceneManager.LoadScene("lvl2");

                break;

            case "Prize":

                SceneManager.LoadScene("WinScreen");

                break;
        }

    } 


	void OnTriggerStay2D(Collider2D other){

		OnTriggerEnter2D (other);
	}
    

}
