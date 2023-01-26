using System;
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public int numberOfEnemies;
    float time;
    public GameObject[] enemiesPrefabs;
    public LevelManager lm;

    public Transform upperBorder;
    public Transform rightBorder;
    public Transform bottomBorder;
    public Transform leftBorder;
    
    public Transform playerTransform;
    private void Start()
    {
        //initialValues();
        spawnEnemy();

    }

    private void initialValues()
    {
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
            Debug.Log(numberOfEnemies);
        }
        
        
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        float x;
        float y;
        time = UnityEngine.Random.Range(1, 5);
        x = UnityEngine.Random.Range(lm.GetMinX(), lm.GetMaxX());
        y = UnityEngine.Random.Range(lm.GetMinY(), lm.GetMaxY());
        Debug.Log(Vector3.Distance(new Vector3(x, y, 0), playerTransform.position));
        if (Vector3.Distance(new Vector3(x, y, 0), playerTransform.position)>5)
        {
            Instantiate(enemiesPrefabs[new System.Random().Next(0,6)], new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
            numberOfEnemies--;
        }
        else
        {
            time = 0;
        }
        yield return new WaitForSeconds(time);
        spawnEnemy();
    }
}
