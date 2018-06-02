using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

    public GameObject model;
    public float timeToRotate = 2f;
    public float rotationSpeed = 6f;

    public GameObject bulletPrefab;
    public float timeToShoot = 1f;

    private Quaternion targetRotation;
    private int targetAngle;
    private float rotationTimer;
    private float shootingTimer;


    void Start () {
        rotationTimer = timeToRotate;
        shootingTimer = timeToShoot;
	}
	

	void Update () {
        // 적의 앵글 업데이트
    rotationTimer -= Time.deltaTime;
        if (rotationTimer <= 0) {
            rotationTimer = timeToRotate;

            targetAngle += 90;    
        }
        // 적의 앵글 순환
        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(0,targetAngle,0),Time.deltaTime * rotationSpeed);

        //총알쏘기
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0) {
            shootingTimer = timeToShoot;

            GameObject bulletObject = Instantiate (bulletPrefab);
            bulletObject.transform.position = transform.position + model.transform.forward;
            bulletObject.transform.forward = model.transform.forward;

            }
	}
}
