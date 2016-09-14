using UnityEngine;
using System.Collections;

public class shootingEnemy : MonoBehaviour {
    private Transform tr_player;
    public float rotSpeed = 1.0f;

    public float movespeed;

    public GameObject Laser;
    public Transform LaserSpawn;
    public float fireRate;

    private float nextFire;

    void Start()
    {
        tr_player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update ()
    {
        if (transform.position.z >= 15)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(tr_player.position - transform.position),
                rotSpeed * Time.deltaTime);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);
            }
        }
        transform.position += transform.forward * movespeed * Time.deltaTime;

        if (transform.position.z <= -30)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
