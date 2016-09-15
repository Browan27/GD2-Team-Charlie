using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    private Rigidbody rb;
    private int enemyPoints = 250;
    private int asteroidPoints = 100;

    private ScoreKeeper gameController;

    public float speed;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
        gameController = gameControllerObject.GetComponent<ScoreKeeper>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update() {
        if (rb.position.z >= 75) {
            GameObject.Destroy (this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            other.gameObject.tag = "DeadEnemy";
            gameController.AddScore (enemyPoints);
            GameObject.Destroy(gameObject);
        } else if (other.CompareTag("Asteroid")) {
            other.gameObject.tag = "DeadAsteroid";
            gameController.AddScore (asteroidPoints);
            GameObject.Destroy(gameObject);
        }
    }
	
}
