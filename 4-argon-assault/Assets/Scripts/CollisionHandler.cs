using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //okay if this is the only script loading scenes

public class CollisionHandler : MonoBehaviour {

    [Tooltip("in seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
    }

    private void ReloadLevel() //called by string method
    {
        SceneManager.LoadScene(1);
    }
}
