using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private int playerRecievedDamage = 1;
	[SerializeField]
	private float speed;

    Transform tr;
    Rigidbody2D rb; 
    float noDamageTime;

    void Start () {

        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>(); 

	}
	
    void Update() {

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
                if(noDamageTime < Time.time) {
                    Player.get_Instance().setHealth(Player.get_Instance().getHealth() - playerRecievedDamage);
                    noDamageTime = Time.time + 4;
                }
                    break;

            case "deathFloor":
                Player.get_Instance().setHealth(-2);
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


//	void OnTriggerStay2D(Collider2D other){
//
//		OnTriggerEnter2D (other);
//	}
//    

}
