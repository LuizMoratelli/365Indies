using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform playerTransform;
    public float speed;

    public float minX;
    public float maxX;

    private void Start() {
        transform.position = new Vector2(playerTransform.position.x, transform.position.y);
    }

    private void Update() {
        if (playerTransform != null) {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);

            transform.position = Vector2.Lerp(transform.position, new Vector2 (clampedX, transform.position.y), speed);
        }
    }
}
