using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Public Variables

    public List<GameObject> objectsToSpawn;
    public float timeOfSpawn;
    public float maxSpawnRandomRadius;

    #endregion

    #region Private Variables

    private float _timeFromSpawn; 

    #endregion

    #region Events

    void Awake()
    {
        _timeFromSpawn = timeOfSpawn;
    }

    void Update()
    {
        if (_timeFromSpawn >= timeOfSpawn)
        {
            SpawnObjects();
        }

        if (_timeFromSpawn < timeOfSpawn)
        {
            _timeFromSpawn += Time.deltaTime;
        }
    }

    #endregion

    #region Private Methods

    private void SpawnObjects()
    {
        foreach (GameObject obj in objectsToSpawn)
        {
            // Check max number of enemies in the scene
            if (GameManager.instance.currentEnemies < GameManager.instance.maxNumEnemies)
            {
                Enemy enemyScript = obj.GetComponent<Enemy>();

                if (enemyScript != null &&
                    (enemyScript.type == EnemyType.Titan || Random.value < enemyScript.ocurrenceProbability))
                {
                    if (enemyScript.type != EnemyType.Titan ||
                        (enemyScript.type == EnemyType.Titan && 
                         GameManager.instance.currentTitans == 0 && 
                         GameManager.instance.killedEnemiesFromLastTitan >= GameManager.instance.killedEnemiesForTitan))
                    {
                        // Instantiate an enemy in a random position
                        Instantiate(
                            obj,
                            new Vector3(
                                Random.Range(transform.position.x - maxSpawnRandomRadius, transform.position.x + maxSpawnRandomRadius),
                                obj.transform.position.y,
                                Random.Range(transform.position.z - maxSpawnRandomRadius, transform.position.z + maxSpawnRandomRadius)),
                            Quaternion.identity);

                        // Update enemies counters
                        GameManager.instance.currentEnemies++;
                        if (enemyScript.type == EnemyType.Titan)
                        {
                            GameManager.instance.currentTitans++;
                            GameManager.instance.killedEnemiesFromLastTitan = 0;
                        }
                    }
                }
            }
        }

        _timeFromSpawn = 0f;
    } 

    #endregion
}
