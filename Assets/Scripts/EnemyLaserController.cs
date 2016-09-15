using UnityEngine;
using System.Collections;

public class EnemyLaserController : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update() {
        if (rb.position.z >= 75 || rb.position.z <=-30) {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //Kill player
        }
    }
}
