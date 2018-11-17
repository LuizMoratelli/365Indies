﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        Debug.Log("a");
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            collision.GetComponent<Enemy>().TakeDamage(3);
        }
    }
}
