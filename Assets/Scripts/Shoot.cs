using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject prefab;
    public Transform bulletSpawn;
    public float timeAlive = 0.25f;

    private bool isFiring = false;

    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        isFiring = true;
        Instantiate(prefab, bulletSpawn.position, bulletSpawn.rotation);

        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("SetFiring", timeAlive);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
