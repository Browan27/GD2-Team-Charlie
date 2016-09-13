using UnityEngine;
using System.Collections;

public class objectDestroyed : MonoBehaviour {

    private MeshRenderer meshRenderer;

    void Start() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //Player Dies
            Explode();
        } else if (other.CompareTag("Laser")) {
            //Player gets points
            Explode();
        }
    }

    void Explode() {
        meshRenderer.enabled = false;
        var exp = GetComponentInChildren<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }
}
