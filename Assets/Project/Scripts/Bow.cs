using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	public GameObject arrowPrefab;

	public void Attack () {
		GameObject arrowObject = Instantiate (arrowPrefab);
		arrowObject.transform.position = transform.position + transform.forward; //화살의 위치는 활의 위치와 활의 앞쪽을 더한값이다.
		arrowObject.transform.forward = transform.forward; //화살의 앞쪽은 활의 앞과 같다.
	}
}
