using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float speed; 

    [SerializeField]
    private GameObject player;

    private Transform tr; 

	// Use this for initialization
	void Start () {

        tr = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        moveEnemy();    
	
	}

    public void moveEnemy()
    {
		Vector2 position = tr.position;
		float playerX = player.transform.position.x;
        float enemyX = tr.position.x; 

		if (enemyX == playerX)
			return;

		position += ((enemyX < playerX) ? Vector2.right * speed : Vector2.left * speed);
		tr.position = position;
    }



}
