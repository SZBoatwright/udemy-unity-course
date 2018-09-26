using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtEnemy : MonoBehaviour {

    // parameters
    [SerializeField] GameObject pivotObject;
    [SerializeField] float maxShootDistance;
    [SerializeField] ParticleSystem beam;

    // state
    Transform targetEnemy;
    public Waypoint baseWaypoint;

    float enemyDistance;
    
    void Update ()
    {
        SetTargetEnemy();
        FireAtEnemies();
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length == 0) return;

        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyDamage en in enemies)
        {
            closestEnemy = ReturnClosest(en.transform, closestEnemy);
        }

        targetEnemy = closestEnemy;
    }

    private Transform ReturnClosest(Transform transA, Transform transB)
    {
        var distanceA = Vector3.Distance(transA.position, transform.position);
        var distanceB = Vector3.Distance(transB.position, transform.position);

        if (distanceA < distanceB)
        {
            return transA;
        }
        return transB;
    }

    private void FireAtEnemies()
    {
        if (targetEnemy)
        {
            enemyDistance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        }
        if (targetEnemy && enemyDistance < maxShootDistance)
        {
            pivotObject.transform.LookAt(targetEnemy.transform);
            beam.Play();
        }
        else
        {
            pivotObject.transform.rotation = Quaternion.Euler(Vector3.forward);
            beam.Pause();
        }
    }
}
