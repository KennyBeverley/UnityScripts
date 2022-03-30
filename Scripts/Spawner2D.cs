using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public bool canSpawn;
    [SerializeField]private GameObject objectToSpawn;
    [SerializeField]private FloatRange spawnDelayRange;
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnDelayRange.min, spawnDelayRange.max);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if(Time.time > nextSpawnTime)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(spawnDelayRange.min, spawnDelayRange.max);
        }
    }
}

[System.Serializable]
public struct FloatRange
{
    public float min;
    public float max;
}
