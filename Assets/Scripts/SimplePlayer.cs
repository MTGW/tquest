	using UnityEngine;
using System.Collections;

public class SimplePlayer : MonoBehaviour {

	Animator animator;
	Transform transform;
	Vector2 currentPosition;
	float movementSpeed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool h = Input.GetButton ("Horizontal");
		bool v = Input.GetButton("Jump");
		bool atk = Input.GetButton ("Fire1");
		currentPosition = transform.position;

		animator.SetBool ("run", h);
		animator.SetBool ("jump",v);
		animator.SetBool ("attack", atk);

		if(Player.get_Instance().getHealth() < 0) {
			animator.SetBool ("dead", true);
		}
		if(h) {
			float horizontalAxis = Input.GetAxis ("Horizontal");
			if (horizontalAxis > 0) {
				currentPosition += Vector2.right * movementSpeed;
			} else if (horizontalAxis< 0) {
				currentPosition += Vector2.left * movementSpeed;
			}

			transform.position = currentPosition;
		}
	}
}
