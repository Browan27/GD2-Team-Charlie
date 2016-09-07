using UnityEngine;
using System.Collections;

public class objectDestroyed : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}
