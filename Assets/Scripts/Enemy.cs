using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
    public float speed;
    public float timeBtwAttacks;
    public Transform player;
    public GameObject extraLife;
    
    public void TakeDamage (int amount) {
        health -= amount;

        if (health <= 0) {
            int rand = Random.Range(0, 100);

            if (rand > 90) {
                Instantiate(extraLife, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }
}
