using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfEnemies;
    float time;
    public GameObject[] enemiesPrefabs;

    float maxX;
    float maxY;
    float minX;
    float minY;

    LevelManager lm;
    private void Start()
    {
        initialValues();
        spawnEnemy();
    }

    private void initialValues()
    {
        lm = FindObjectOfType<LevelManager>();
        switch (lm.numWave)
        {
            case 1:
                numberOfEnemies = 30;
                break;
        }
    }

    private void spawnEnemy()
    {
        if (numberOfEnemies > 0)
        {
            StartCoroutine(SpawnEnemyCoroutine());
        }
        numberOfEnemies--;
        
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        time = UnityEngine.Random.Range(1, 10);
        float x = UnityEngine.Random.Range(lm.GetMinX(), lm.GetMaxX());
        float y = UnityEngine.Random.Range(lm.GetMinY(), lm.GetMaxY());
        Instantiate(enemiesPrefabs[5],new Vector3(x,y,0),Quaternion.Euler(0,0,0));
        yield return new WaitForSeconds(time);
        spawnEnemy();
    }
}
