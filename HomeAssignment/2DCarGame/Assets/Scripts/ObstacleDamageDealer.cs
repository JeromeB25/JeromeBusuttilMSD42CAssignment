using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int Damage()
    {
        return damage;
    }

    public void ObstacleHit()
    {
        Destroy(gameObject);
    }
}
