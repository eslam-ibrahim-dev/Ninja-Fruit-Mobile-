using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnfruit : MonoBehaviour
{

    public GameObject SpawnFruit;
    public Transform[] SpawnPoints;
    public float mintime = 0.1f;
    public float maxtime = 1f;
    void Start()
    {
     
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            float delay = Random.Range(mintime, maxtime);
            yield return new WaitForSeconds(delay);
            int points = Random.Range(0, SpawnPoints.Length);
            Transform spawnpoint = SpawnPoints[points];
            GameObject fruit= Instantiate(SpawnFruit,spawnpoint.position,spawnpoint.rotation);
            Destroy(fruit,5f);
        }
    }
}
