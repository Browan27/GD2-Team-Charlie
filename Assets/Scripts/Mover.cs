﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update() {
        if (rb.position.z >= 75) {
            GameObject.Destroy (this.gameObject);
        }
    }
	
}
