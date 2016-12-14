using UnityEngine;
using System.Collections;

public class Player{

	private int score, health, highScore, lives;

	private static Player _instance;
	private bool dead;

	public static Player get_Instance(){
		if (_instance == null) { 
			_instance = new Player (); 
		}
		return _instance; 
	}

	// delete constructor. Only using to stop Null Exceptions
	private Player(){
		score = 0;
		health = 100;
		highScore = 0;
		lives = 3;
	}
	public int getScore(){ 
		return this.score; 
	}
	public void setScore (int score){ 
		this.score = score; 
	}

	public int getHealth(){ 
		return this.health;
	}
	public void setHealth(int health){ 
		this.health = health; 
		if (health < 0) {
			lives--;
		}
	} 

	public int getLives(){ 
		return this.lives; 
	}
	public void setLives(int lives){ 
		this.lives = lives; 
		if (lives < 0) {
			// some game over shit here
		}
	}

	public int getHighScore(){ 
		return this.highScore; 
	}
	public void getHeighScore(int highScore){ 
		this.highScore = highScore;
	}


	public void collectCoin(){ 
		this.score++; 
	}

}
