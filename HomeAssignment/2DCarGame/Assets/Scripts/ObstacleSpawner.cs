using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<Wave> waveConfigList;

    [SerializeField] bool looping = false;

    //Always start from wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            //start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //while (looping == true)
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAllEnemiesInWave(Wave waveToSpawn)
    {
        //spawns an enemy till enemyCount = getNumberOfEnemies()
        for (int enemyCount = 0; enemyCount < waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn the enemy from waveConfig at the position specified by waveConfig waypoints
            var newEnemy = Instantiate(
                    waveToSpawn.GetEnemyPrefab(),
                    waveToSpawn.GetWaypoints()[0].transform.position,
                    Quaternion.identity);

            newEnemy.GetComponent<ObstacleMovements>().setWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (Wave currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}

