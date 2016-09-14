using UnityEngine;
using System.Collections;

public class SpawningWaves : MonoBehaviour {

    public GameObject hazard;
    public GameObject badGuy;
    public Vector3 spawnValues;
    public int numOfAstroids;
    public int numOfBadGuys;
    public float waveWaitAstroids;
    public float waveWaitBadGuys;
    public float startWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnBadGuys());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < numOfAstroids; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(waveWaitAstroids);
        }
    }

    IEnumerator SpawnBadGuys() {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < numOfBadGuys; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            spawnRotation.y = -180.0f;

            Instantiate(badGuy, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(waveWaitBadGuys);
        }
    }
}
