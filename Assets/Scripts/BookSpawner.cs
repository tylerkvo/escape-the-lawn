using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public GameObject bookPrefab;
    public float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnBook), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBook()
    {
        Instantiate(bookPrefab, transform.position, Quaternion.identity);
    }
}
