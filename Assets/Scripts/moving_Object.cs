using UnityEngine;
using System.Collections;

public class moving_Object : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        rb.velocity = transform.forward * speed;
    }

    void Update() {
        if (rb.position.z <= -20) {
            GameObject.Destroy (this.gameObject);
        }
    }
}
