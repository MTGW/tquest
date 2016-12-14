using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LevelManager : MonoBehaviour {


	[SerializeField]
	private Text health; 
	[SerializeField]
	private Text score; 
	[SerializeField]
	private Text lives;

	Player player;

    private Transform playerObj;


    private Transform camPosition; 


	void Start () {
		setStats (); 

		player = Player.get_Instance();

        camPosition = GetComponent<Transform>();

        playerObj = GameObject.FindGameObjectWithTag("Player").transform;

	}


	void Update () {
		setStats ();

        setCamPos( getPlayerLocation() );
	}



	public void setStats(){ 
		//health.text = "Health : " + player.getHealth ();
		//score.text  = "Score : " + player.getScore(); 
		//lives.text = "Lives : " + player.getLives();
	}




    public Vector3 getPlayerLocation()
    {
        return new Vector3(playerObj.position.x, playerObj.position.y, (float)-10 );
    }

    public void setCamPos( Vector3 playerPos )
    {
        camPosition.position = playerPos;
    }

}
