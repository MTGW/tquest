using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    int damage;

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Player") {
            Animator playerAnimator = other.gameObject.GetComponent<Animator>();
            if(playerAnimator.GetCurrentAnimatorStateInfo == "attack" ||
               playerAnimator.GetCurrentAnimatorStateInfo == "jumpAtk") {
                Destroy(gameObject);
            } else {
                Player.get_Instance().setHealth(Player.get_Instance().getHealth() - damage);
            }
        }
    }
    // Just in case OnTriggerEnter2D() doesn't invoke on enter.
    void OnTriggerStay2D(Collider2D other){

        OnTriggerEnter2D(other);
    }

}
