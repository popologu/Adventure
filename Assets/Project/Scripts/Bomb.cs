using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float duration = 5f;
	public float radius = 3f;
	public float explosionDuration = 0.25f;
	public GameObject explosionModel;

	private float explosionTimer;
	private bool exploded;

	// Use this for initialization
	void Start () {
		explosionTimer = duration;
		explosionModel.transform.localScale = Vector3.one * radius;  // 폭탄 스케일 
		explosionModel.SetActive(false); // 폭탄 오브젝트 처음에는 꺼두기(첨부터 나오면)
	}
	
	// Update is called once per frame
	void Update () {
		explosionTimer -= Time.deltaTime;
		if (explosionTimer <= 0f && exploded == false) {
			exploded = true;
			// Collider[] hitObject = Physics.OverlapSphere(transform.position, radius);

			// foreach (Collider collider in hitObject) {
			// 	Debug.Log(collider.name + " was hit!");

			// }
			StartCoroutine (Explode());

		}
	}

	private IEnumerator Explode() {
		explosionModel.SetActive(true);

		yield return new WaitForSeconds (explosionDuration);
		
		Destroy (gameObject);
	}
}
