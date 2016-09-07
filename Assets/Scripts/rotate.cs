using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    public float tumble;
    public Rigidbody rb;

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
