using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnTime;
    public GameObject unitToSpawn;

    public float numToSpawn = 4;
    public float radius;
    List<GameObject> units;
    float nextSpawnTime;
    
    void Start()
    {
        nextSpawnTime = Time.time;
        units = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject unit in units.ToArray()) {
            if (unit == null) {
                units.Remove(unit);
            }
        }

        if (Time.time > nextSpawnTime && units.Count < numToSpawn) {
            units.Add(Instantiate(unitToSpawn, gameObject.transform.position - new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0f), Quaternion.identity));
            nextSpawnTime = Time.time + spawnTime;
        }
    }
}
