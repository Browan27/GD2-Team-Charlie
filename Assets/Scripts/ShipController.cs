using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerBoundary {
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}

public class ShipController : MonoBehaviour {

    public float moveSpeed = 20.0f;
    public PlayerBoundary boundary;
    public float frontTilt;
    public float sideTilt;
    public float rotationTilt;
    public float tiltSpeed;
    public float turnSpeed;

    private Rigidbody rb;
    private Vector3 movement;
    private float movementHorizontalInputValue;
    private float movementVerticalInputValue;

    public GameObject Laser;
    public Transform LaserSpawn;
    public float fireRate;

    private float nextFire;

    void Awake () {
        rb = GetComponent<Rigidbody> ();
    }

    void Update () {
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
            Fire ();
        }
    }

    void FixedUpdate () {
        float movementHorizontalInputValue = Input.GetAxisRaw ("Horizontal");
        float movementVerticalInputValue = Input.GetAxisRaw ("Vertical");
        Move (movementHorizontalInputValue, movementVerticalInputValue);
    }

    void Move (float h, float v) {
        movement.Set (h, v, 0.0f);

        rb.velocity = movement * moveSpeed;
        rb.position = new Vector3 (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        Quaternion futureRotationInXAndZAxis = Quaternion.Euler(rb.velocity.y * -sideTilt, 0.0f, rb.velocity.x * -frontTilt);
        rb.rotation = Quaternion.Lerp (rb.rotation, futureRotationInXAndZAxis, Time.deltaTime * tiltSpeed);
        Quaternion futureRotationInxYAxis = Quaternion.Euler(rb.rotation.x, rb.velocity.x * rotationTilt, rb.rotation.z);
        rb.rotation = Quaternion.Lerp(rb.rotation, futureRotationInxYAxis, Time.deltaTime * turnSpeed);
    }

    void Fire () {
        nextFire = Time.time + fireRate;
        Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);
    }
}
