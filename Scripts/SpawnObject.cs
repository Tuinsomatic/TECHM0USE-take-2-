using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectPrefab;

    public void Spawn()
    {
        Instantiate(objectPrefab, transform.position, transform.rotation);
    }
}