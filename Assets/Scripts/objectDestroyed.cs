using UnityEngine;
using System.Collections;

public class objectDestroyed : MonoBehaviour {

    GameObject explosion;

    void OnTriggerEnter(Collider other) {
        Explode();
    }

    void Explode() {
        var exp = GetComponentInChildren<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }
}
