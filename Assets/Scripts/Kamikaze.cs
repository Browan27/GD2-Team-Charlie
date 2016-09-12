using UnityEngine;
using System.Collections;

public class Kamikaze : MonoBehaviour
{
    public Transform tr_player;
    float rotSpeed = 3.0f;
    public float movespeed;

    void Start()
    {
        tr_player = GameObject.FindGameObjectWithTag("PlayerShip").transform;
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(tr_player.position - transform.position),
            rotSpeed * Time.deltaTime);

        transform.position += transform.forward * movespeed * Time.deltaTime;
    }
}