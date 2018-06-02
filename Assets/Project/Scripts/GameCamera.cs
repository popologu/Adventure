using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;
    public float focusSpeed = 1f;

	void Start () {
        //offset = transform.position - target.transform.position;
	}
	

	void Update () {
        if (target != null) {
            transform.position = Vector3.Lerp(transform.position,target.transform.position + offset,focusSpeed * Time.deltaTime);
            }
        
           
	}
}
