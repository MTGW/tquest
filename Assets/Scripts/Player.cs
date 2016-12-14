using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player{

	private int score, health, highScore, lives;

	private static Player _instance;
	private bool dead;

	public static Player get_Instance() {
        
		if(_instance == null) { 
			_instance = new Player (); 
			_instance.score = 0;
			_instance.health = 2;
			_instance.highScore = 0;
			_instance.lives = 3;
		}
		return _instance; 
	}

	private Player() {

	}
	public int getScore() { 
		return score; 
	}
	public void setScore (int score) { 
		this.score = score; 
	}

	public int getHealth() { 
		return health;
	}
	public void setHealth(int health) { 
		this.health = health; 
		if (health <= 0) {
			this.health = 0;
			setLives(this.lives - 1);
		}
        Debug.Log("Health: " + health);
	} 

	public int getLives() { 
		return lives; 
	}
	public void setLives(int lives) { 
		this.lives = lives; 
		if (lives <= 0) {
			this.lives = 0;
			SceneManager.LoadScene ("start");
        }
			health = 2;
	}

	public int getHighScore() { 
		return highScore; 
	}
	public void getHeighScore(int highScore) { 
		this.highScore = highScore;
	}


	public void collectCoin() { 
		this.score++; 
	}

}
