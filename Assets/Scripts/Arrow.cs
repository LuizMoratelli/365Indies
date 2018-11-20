using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private Player playerScript;
    private Vector2 targetPosition;
    public float speed;
    public float ttl;
    public int damage;

	void Start () {
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
        StartCoroutine("Destroy");
	}
	
	void Update () {
		//if (Vector2.Distance(transform.position, targetPosition) > 0.1f) {
        //    transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //}
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    IEnumerator Destroy () {
        yield return new WaitForSeconds(ttl);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Destroy(this.gameObject);
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
