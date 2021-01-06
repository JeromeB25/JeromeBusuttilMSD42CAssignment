using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float shotcounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject ObstacleBulletPrefab;
    [SerializeField] float ObstacleBulletSpeed = 0.3f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamageDealer class from otherObject which hits enemy and reduce health accordingly
        ObstacleDamageDealer dmgDealer = otherObject.gameObject.GetComponent<ObstacleDamageDealer>();

        if (!dmgDealer)
        {
            return;
        }
    }

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
