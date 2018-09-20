using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtEnemy : MonoBehaviour {

    [SerializeField] GameObject pivotObject;
    [SerializeField] GameObject enemy;
    [SerializeField] float maxShootDistance;
    [SerializeField] ParticleSystem beam;

    float enemyDistance;
    
    void Update ()
    {
        FireAtEnemies();
    }

    private void FireAtEnemies()
    {
        if (enemy)
        {
            enemyDistance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        }
        if (enemy && enemyDistance < maxShootDistance)
        {
            pivotObject.transform.LookAt(enemy.transform);
            beam.Play();
        }
        else
        {
            pivotObject.transform.rotation = Quaternion.Euler(Vector3.forward);
            beam.Pause();
        }
    }
}
