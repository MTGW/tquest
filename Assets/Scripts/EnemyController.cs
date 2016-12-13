using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    float speed;

    GameObject player;
    bool alive;

    void Start(){

        StartCoroutine("move");
        player = GameObject.Find("Player");
        alive = true;


    }

    IEnumerator move(){
    
        while(alive) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

            if(hit != null) {
                Vector2.Lerp(transform.position, player.transform.position, speed);
            }
            yield return null;
        }
    }
}
