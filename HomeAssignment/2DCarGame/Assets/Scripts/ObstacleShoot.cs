using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShoot : MonoBehaviour
{
    //Serialize Fields 
    [SerializeField] float shotcounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject ObstacleBulletPrefab;
    [SerializeField] float ObstacleBulletSpeed = 0.3f;
    [SerializeField] AudioClip obstacleShoot;
    [SerializeField] [Range(0, 1)] float obstacleShootVolume = 0.5f;



    // Update is called once per frame
    void Start()
    {
        //generate a random number
        shotcounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduce the amount for shot
        shotcounter -= Time.deltaTime;

        if (shotcounter <= 0f)
        {
            EnemyFire();
            //reset shotCounter
            shotcounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject ObstacleBullet = Instantiate(ObstacleBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //shoot bullet downwards
        ObstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ObstacleBulletSpeed);
    }
}
