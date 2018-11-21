using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayer : MonoBehaviour {

	public float speed;
    public float ttl;

	void Start () {
		StartCoroutine("Destroy");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    IEnumerator Destroy () {
        yield return new WaitForSeconds(ttl);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            Destroy(this.gameObject);
            collision.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}
