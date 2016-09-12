using UnityEngine;
using System.Collections;

public class Kamikaze : MonoBehaviour
{
    private Transform tr_player;
    public float rotSpeed = 1.0f;

    public float movespeed;

    void Start()
    {
        tr_player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        if (transform.position.z >= 15) {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(tr_player.position - transform.position),
                rotSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * movespeed * Time.deltaTime;
    }
}