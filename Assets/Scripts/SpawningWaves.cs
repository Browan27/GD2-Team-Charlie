using UnityEngine;
using System.Collections;

public class SpawningWaves : MonoBehaviour {

    private ScoreKeeper gameController;

    public GameObject hazard;
    public GameObject badGuy;
    public GameObject shootingBadGuy;
    public Vector3 spawnValues;
    public int numOfAstroids;
    public int numOfBadGuys;
    public int numOfShootingBadGuys;
    public float waveWaitAstroids;
    public float waveWaitBadGuys;
    public float waveWaitShootingBadGuys;
    public float startWait;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<ScoreKeeper>();
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnBadGuys());
        StartCoroutine(SpawnShootingBadGuys());
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
            if (gameController.gameOver) {
                yield break;
            }
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
            if (gameController.gameOver) {
                yield break;
            }
        }
    }

    IEnumerator SpawnShootingBadGuys() {
        yield return new WaitForSeconds(startWait);
        for (int i = 0; i < numOfShootingBadGuys; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            spawnRotation.y = -180.0f;

            Instantiate(shootingBadGuy, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(waveWaitShootingBadGuys);
            if (gameController.gameOver) {
                yield break;
            }
        }
    }
}
