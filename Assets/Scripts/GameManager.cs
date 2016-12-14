using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    
	[SerializeField]
	private Text highScore; 

	void Start () {
        
        // highScore is null until GUI is made
		// highScore.text = "HighScore : " + Player.get_Instance().getHighScore();
	}

	void Update () {
	
	}
	public void startGame(){

		SceneManager.LoadScene ("lvl1");

	}

}
