using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class levelManeger : MonoBehaviour {


	[SerializeField]
	private Text health; 
	[SerializeField]
	private Text score; 
	[SerializeField]
	private Text lives;

	Player player;

	void Start () {
		setStats (); 

		player = Player.get_Instance();
	}


	void Update () {
		setStats (); 
	}



	public void setStats(){ 
		health.text = "Health : " + player.getHealth ();
		score.text  = "Score : " + player.getScore(); 
		lives.text = "Lives : " + player.getLives();
	}

}
