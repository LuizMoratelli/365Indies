using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public GameObject arrowPrefab;
    public float timeBtwAttacks;
    private float attackTime;
    private Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void Update () {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (player.isLeft) {
            angle -= 180;
        }

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (Time.time >= attackTime) {
            if (Input.GetButtonDown("Fire1")) {
                if (!player.isLeft) {
                    angle -= 180;
                }

                Quaternion rotationArrow = Quaternion.AngleAxis(angle, Vector3.forward);
                Instantiate(arrowPrefab, transform.position, rotationArrow);
                attackTime = Time.time + timeBtwAttacks;
            }
        }
	}
}
