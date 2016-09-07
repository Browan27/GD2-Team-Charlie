using UnityEngine;
using System.Collections;

public class SpawningWaves : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int numOfHazards;
    public float waveWait;
    public float startWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(waveWait);
        for (int i = 0; i < numOfHazards; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(waveWait);
        }
    }
}
