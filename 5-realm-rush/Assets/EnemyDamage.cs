using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] GameObject damager;
    [SerializeField] int enemyHealth = 5;

    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem hitFX;

    bool enemyIsDead = false;

    private void OnParticleCollision(GameObject particle)
    {
        enemyHealth -= 1;
        hitFX.Play();

        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        enemyIsDead = true;
        Instantiate(deathFX, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject);
    }

    public bool isEnemyDead ()
    {
        return enemyIsDead;
    }
}
