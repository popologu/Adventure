using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float swingingSpeed = 2f;  // 칼이 내려가는 속도
	public float cooldownSpeed = 2f; // 칼을 휘두르고 다시 처음 위치로 돌아오는 시간(높으면 빨리 돌아옴)
	public float attackDuration = 0.35f; // 칼이 내려가고 유지되는 시간
	public float cooldownDuration = 0.5f;  // 칼을 휘두르고 다음 휘두르기 까지 걸리는 시간

	private Quaternion targetRotation;
	private float cooldownTimer;
	private bool isAttacking;

	// Use this for initialization
	void Start () {
		targetRotation = Quaternion.Euler (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, (isAttacking ? swingingSpeed : cooldownSpeed) * Time.deltaTime );
		
		cooldownTimer -= Time.deltaTime;
	}

	public void Attack () {
		if(cooldownTimer > 0f) {
			return;
		}

		targetRotation = Quaternion.Euler (90, 0, 0);

		cooldownTimer = cooldownDuration;

		StartCoroutine (CooldownWait());
	}

	private IEnumerator CooldownWait () {
		isAttacking = true;

		yield return new WaitForSeconds (attackDuration);

		isAttacking = false;

		targetRotation = Quaternion.Euler (0, 0, 0);

	}

	
}
