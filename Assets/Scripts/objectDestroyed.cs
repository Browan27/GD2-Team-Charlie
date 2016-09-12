using UnityEngine;
using System.Collections;

public class objectDestroyed : MonoBehaviour {

    GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);

    }
}
