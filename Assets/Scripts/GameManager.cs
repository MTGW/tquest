using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	[SerializeField]
	private Text highScore; 


	// Use this for initialization
	void Start () {
		highScore.text = "HighScore : " + Player.get_Instance().getHighScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void startGame(){

		SceneManager.LoadScene ("lvl1");

	}

}
