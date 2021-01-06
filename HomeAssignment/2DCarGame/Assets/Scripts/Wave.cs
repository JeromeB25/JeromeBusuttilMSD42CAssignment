using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class Wave : ScriptableObject

{
    [SerializeField] GameObject enemyPrefab;

    //the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each enemy to spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between enemey spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //enemies in the wave
    [SerializeField] int numberOfEnemies = 5;

    //espeed of the enemy
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //access pathPrefab and for each child add it to the list
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

