using UnityEngine;
using System.Collections;

public class Kamikaze : MonoBehaviour {

    private Transform myTransform;
    public int maxDistance;
    public Transform target;
    public int rotationSpeed;
    public int moveSpeed;

    void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("PlayerShip");

        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.yellow);

        //Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
        {
            //Move towards target
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
