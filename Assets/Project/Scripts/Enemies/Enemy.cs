using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 1;

	public virtual void Hit () {
		health--;
		if (health <=0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider othercollider){
		if (othercollider.GetComponent<Sword> () != null) {
			if(othercollider.GetComponent<Sword> ().IsAttacking) {
				Hit ();
			}
		}else if (othercollider.GetComponent<Arrow> () != null) {
			Hit ();
			Destroy (othercollider.gameObject);
		}
	}
}
