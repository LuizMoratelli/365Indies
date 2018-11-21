using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Atributos")]
    public float movementSpeed;
    public float jumpForce;
    private bool isGrounded;
    public int health;
    public bool isLeft;

    [Header("Componentes")]
    private Rigidbody2D _rigidbody;
    public GameObject _start;
    public GameObject _groundCheck;

    [Header("Armas")]
    public GameObject _trident;

	void Start () {
		_rigidbody = GetComponent<Rigidbody2D>();
        transform.position = _start.transform.position;
	}

	void Update () {
		float horizontal = Input.GetAxisRaw("Horizontal");
        float speedY = _rigidbody.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded) {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        _rigidbody.velocity = new Vector2 (horizontal * movementSpeed, speedY);

        if ((isLeft && horizontal > 0) || (!isLeft && horizontal < 0)) {
            Flip();
        }
	}

    private void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(_groundCheck.transform.position, 0.02f);
    }

    public void TakeDamage (int amount) {
        health -= amount;

        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void Flip () {
        isLeft = !isLeft;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
