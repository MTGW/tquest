	using UnityEngine;
using System.Collections;

public class SimplePlayer : MonoBehaviour {

	Animator animator;
	Vector2 currentPosition;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float movementSpeed;
	[SerializeField]
	GameObject rightDamageCollider;
    [SerializeField]
    GameObject leftDamageCollider;

	void Start() {
        
		animator = GetComponent<Animator> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update() {
        
		bool h = Input.GetButton ("Horizontal");
		bool v = Input.GetButton("Jump");
		bool atk = Input.GetButton ("Fire1");
		currentPosition = transform.position;

		animator.SetBool ("run", h);
		animator.SetBool ("jump",v);
        animator.SetBool ("attack", atk);

        // Depending on the direction Player is facing, the apprieate Damage Collider is enabled.
        // Note: SpriteRenderer.flipX does not flip colliders.
        if(atk) {
            if(spriteRenderer.flipX) {
                rightDamageCollider.SetActive(false);
                leftDamageCollider.SetActive(true);
            } else {
                rightDamageCollider.SetActive(true);
                leftDamageCollider.SetActive(false);
            }
        } else {
            rightDamageCollider.SetActive(false);
            leftDamageCollider.SetActive(false);
        }

		if (Player.get_Instance ().getHealth () <= 0) {
			animator.SetBool ("dead", true);
		} else {
			animator.SetBool ("dead", false);
		}

        if(h && !atk) {
			float horizontalAxis = Input.GetAxis ("Horizontal");

			if (horizontalAxis > 0) {
				currentPosition += Vector2.right * movementSpeed;
                spriteRenderer.flipX = false;
			} else if (horizontalAxis < 0) {
				currentPosition += Vector2.left * movementSpeed;
                spriteRenderer.flipX = true;
			}

			transform.position = currentPosition;
		}
	}
}
