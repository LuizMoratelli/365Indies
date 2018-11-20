using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy {

    public float stopDistance;
    public float sightDistance;
    private float attackTime;
    public Transform shotPoint;
    public GameObject arrowPrefab;
    public bool isRight;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
		if (player != null) {
            if ((isRight && player.position.x < transform.position.x) || (!isRight && player.position.x > transform.position.x)) {
                Flip ();
            }

            float distanceBtwPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceBtwPlayer > stopDistance && distanceBtwPlayer < sightDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (distanceBtwPlayer < sightDistance) {
                if (Time.time >= attackTime) {
                    attackTime = Time.time + timeBtwAttacks;
                    RangedAttack();
                }
            }
        }
	}

    public void RangedAttack() {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(arrowPrefab, shotPoint.position, shotPoint.rotation);
    }

    public void Flip() {
        isRight = !isRight;
        transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
    }
}
