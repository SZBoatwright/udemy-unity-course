using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyMovement enemy;
    [SerializeField] float secondsBetweenSpawn = 1.75f;
    [SerializeField] AudioClip spawnSFX;

    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            EnemyMovement newEnemy = Instantiate(enemy, transform.position, new Quaternion(0, 0, 0, 0));
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
