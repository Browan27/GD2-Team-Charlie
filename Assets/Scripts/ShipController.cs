using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float moveSpeed = 20.0f;

	private Rigidbody rb;
	private Vector3 movement;
	private float movementHorizontalInputValue;
	private float movementVerticalInputValue;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Start () {
		
	}

	void Update () {

	}

	void FixedUpdate () {
		float movementHorizontalInputValue = Input.GetAxisRaw ("Horizontal");
		float movementVerticalInputValue = Input.GetAxisRaw ("Vertical");
		Move (movementHorizontalInputValue, movementVerticalInputValue);
	}

	void Move (float h, float v) {
		movement.Set (h, v, 0.0f);
		movement = movement.normalized * moveSpeed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
	}
}
