using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
       
    }

    private void Update()
    {
        
    }

}
