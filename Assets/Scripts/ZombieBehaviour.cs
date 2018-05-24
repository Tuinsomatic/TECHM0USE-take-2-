using System.Collections;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health = 10;
    public int damage = 2;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;

    public Transform player;

    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;

            GetComponent<MoveTowards>().target = player;
            GetComponent<LookAtPlayer>().target = player;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustExplosionAngle);

            Instantiate(explosionPrefab, transform.position, newRot);

            GetComponent<AddScore>().DoSendScore();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        }
    }
}
