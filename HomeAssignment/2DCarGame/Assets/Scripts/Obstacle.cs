using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ 
    [SerializeField] float health = 1f;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamageDealer class from otherObject which hits enemy and reduce health accordingly
        ObstacleDamageDealer dmgDealer = otherObject.gameObject.GetComponent<ObstacleDamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(ObstacleDamageDealer dmgDealer)
    {
        health -= dmgDealer.Damage();
        dmgDealer.ObstacleHit();

        if (health <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
       
    }

    private void Update()
    {
        
    }

}
