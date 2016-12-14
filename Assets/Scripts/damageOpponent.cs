using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damageOpponent : MonoBehaviour
{
	[SerializeField]
	GameObject coin;

	public void OnTriggerEnter2D(Collider2D other){

        Debug.Log (other.tag.ToString() ,coin);

		if (other.tag == "Enemy"){
			Destroy (other.gameObject);

            Instantiate(coin, other.gameObject.transform);
		}
	}

	public void OnTriggerStay2D(Collider2D other){

		OnTriggerEnter2D (other);
	}

}
