using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] GameObject damager;
    [SerializeField] int enemyHealth = 5;

    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem hitFX;

    private void OnParticleCollision(GameObject other)
    {
        if(other == damager)
        {
            enemyHealth -= 1;
            hitFX.Play();

            if (enemyHealth <= 0)
            {
                KillEnemy();
            }
        }    
    }

    private void KillEnemy()
    {
        print("HE DEED!!!!1");
        deathFX.Play();
        //sound effect
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
