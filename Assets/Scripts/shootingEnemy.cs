using UnityEngine;
using System.Collections;

public class shootingEnemy : MonoBehaviour {
    private Transform tr_player;
    public float rotSpeed = 1.0f;

    public float movespeed;

    public GameObject Laser;
    public Transform LaserSpawn;
    public float fireRate;
    public float secondShotDelay;
    public int numberOfShotsInBurst;

    private float nextFire;
    private int shotsFired = 0;


    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player")) {
            tr_player = GameObject.FindGameObjectWithTag("Player").transform;
        } else {
            tr_player = null;
        }
	
    }
	
	void Update ()
    {
        if (transform.position.z >= 15 && tr_player)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(tr_player.position - transform.position),
                rotSpeed * Time.deltaTime);
            if (Time.time > nextFire)
            {
                if (shotsFired % numberOfShotsInBurst == 0) {
                    nextFire = Time.time + fireRate;
                } else {
                    nextFire = Time.time + secondShotDelay;
                }
                Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);
                shotsFired++;
            }
        }
        transform.position += transform.forward * movespeed * Time.deltaTime;

        if (transform.position.z <= -30)
        {
			//audio.PlayOneShot (explosion_enemy);
            GameObject.Destroy(this.gameObject);

        }
    }
}
