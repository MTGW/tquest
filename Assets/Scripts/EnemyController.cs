using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	float speed;
	[SerializeField]
	GameObject player;

	bool isAlive;
    Renderer rendererObj;
	SpriteRenderer spriteRenderer;

    void Awake() {

        isAlive = true;
        rendererObj = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Init Health: " + Player.get_Instance().getHealth());
    }

    void OnBecameVisible() {

		StartCoroutine ("move");
	}
    void OnBecomeInvisible(){
    
        StopCoroutine("move");
    }

	IEnumerator move() {

        while(isAlive && 
                Vector2.Distance(transform.position, player.transform.position) > 1f){
			RaycastHit2D hit = Physics2D.Raycast (
				new Vector2(transform.position.x - 1f, transform.position.y),
				Vector2.down, 
                rendererObj.bounds.size.y / 2 + 1.5f
            );
            Debug.Log(hit.collider);
            if(hit.collider != null && hit.collider.tag != "enemy") {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
                if(transform.position.x > player.transform.position.x) {
                    spriteRenderer.flipX = true;
                }
                else {
                    spriteRenderer.flipX = false;
                }

            }      
            yield return null;
        }
    }
}
