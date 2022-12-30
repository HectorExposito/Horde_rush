using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numWave;

    float maxX;
    float maxY;
    float minX;
    float minY;
    void Start()
    {
        numWave = 1;
        setBorders();
    }

    private void setBorders()
    {
        GameObject[] borders = new GameObject[4];
        borders = GameObject.FindGameObjectsWithTag(Tags.border);
        foreach (GameObject b in borders)
        {
            if (b.transform.position.x + b.GetComponent<BoxCollider2D>().offset.x > maxX)
            {
                maxX = b.transform.position.x + b.GetComponent<BoxCollider2D>().offset.x;
            }
            else if (b.transform.position.x + b.GetComponent<BoxCollider2D>().offset.x < minX)
            {
                minX = b.transform.position.x + b.GetComponent<BoxCollider2D>().offset.x;
            }

            if (b.transform.position.y + b.GetComponent<BoxCollider2D>().offset.y > maxY)
            {
                maxY = b.transform.position.y + b.GetComponent<BoxCollider2D>().offset.y;
            }
            else if (b.transform.position.y + b.GetComponent<BoxCollider2D>().offset.y < minY)
            {
                minY = b.transform.position.y + b.GetComponent<BoxCollider2D>().offset.y;
            }
        }
    }

    public float GetMinY()
    {
        return minY;
    }

    public float GetMinX()
    {
        return minX;
    }

    public float GetMaxY()
    {
        return maxY;
    }

    public float GetMaxX()
    {
        return maxX;
    }
    
}
