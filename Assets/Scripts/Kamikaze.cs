using UnityEngine;
using System.Collections;

public class Kamikaze : MonoBehaviour
{
    private Transform tr_player;
    public float rotSpeed = 1.0f;

    public float movespeed;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player")) {
            tr_player = GameObject.FindGameObjectWithTag("Player").transform;
        } else {
            tr_player = null;
        }
        
    }

    void Update()
    {
        if (transform.position.z >= 15 && tr_player) {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(tr_player.position - transform.position),
                rotSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * movespeed * Time.deltaTime;

        if (transform.position.z <= -30) {//Destroy if out of camera
            GameObject.Destroy(this.gameObject);
        }
    }
}