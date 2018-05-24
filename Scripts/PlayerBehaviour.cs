using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;

    public int health = 100;

    private Animator gunAnim;

    void Start()
    {
        gunAnim = GetComponent<Animator>();

        SendHealthData();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        SendHealthData();

        if (health <= 0)
        {
            Die();
            //SceneManager.LoadScene("Game Over");
        }
    }
 

    void Die()
    {
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x,
                                                 transform.eulerAngles.y,
                                                 transform.eulerAngles.z + adjustExplosionAngle);

        Instantiate(explosionPrefab, transform.position, newRot);
        Destroy(gameObject);
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}

