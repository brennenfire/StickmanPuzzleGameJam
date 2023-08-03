using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject garbageBall;
    [SerializeField] float middleToLeft;
    [SerializeField] float middleToRight;
    Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = new Vector3(0, 0, 0);
        SpawnBall();    
    }

    void SpawnBall()
    {
        StartCoroutine(SpawnNextBall());
    }

    IEnumerator SpawnNextBall()
    {
        var sizeRandom = UnityEngine.Random.Range(1f, 2f);
        spawnPosition.x = UnityEngine.Random.Range(middleToRight, middleToLeft);
        yield return new WaitForSeconds(0.5f);
        GameObject newObject = Instantiate(garbageBall, transform.position + spawnPosition, Quaternion.identity);
        newObject.transform.localScale = new Vector3(sizeRandom, sizeRandom, 1f);
        SpawnBall();
    }
}
