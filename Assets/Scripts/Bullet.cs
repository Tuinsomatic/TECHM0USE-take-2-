using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10.0f;
    public float duration = 0.7f;

	void Start () {
        Invoke("Die", duration);
	}
	
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke("Die");
    }
    void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
