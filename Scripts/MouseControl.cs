using System.Collections;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rgbd;

	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rgbd.velocity = new Vector2(x, y) * speed;
        rgbd.angularVelocity = 0.0f;
	}
}
