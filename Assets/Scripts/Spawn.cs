using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] obstaculos;

    public float timeSpawn;

    public float repeatSpawnRate;

    [SerializeField] float Ymin, Ymax;
    [SerializeField] Transform Limit;


    void Start()
    {
        InvokeRepeating("SpawnObstaculos" , timeSpawn, repeatSpawnRate);

    }

    
    void Update()
    {
        
    }

    public void SpawnObstaculos()
    {
        int i = Random.Range(0, 3);
        float y = Random.Range(Ymin, Ymax);
        Instantiate(obstaculos[i], new Vector3(Limit.position.x, y, 0), Quaternion.identity);
    }
}
