using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] EnemyMovement enemy;
    [SerializeField] float secondsBetweenSpawn = 1.75f;
    
	void Start () {
        StartCoroutine(spawnEnemy());
	}

    IEnumerator spawnEnemy ()
    {
        while (true)
        {
            EnemyMovement newEnemy = Instantiate(enemy, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
