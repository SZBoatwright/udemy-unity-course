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
            StartCoroutine(KillEnemy());
        }
    }

    IEnumerator KillEnemy()
    {
        enemyIsDead = true;
        deathFX.Play();
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1);
        //sound effect
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool isEnemyDead ()
    {
        return enemyIsDead;
    }
}
