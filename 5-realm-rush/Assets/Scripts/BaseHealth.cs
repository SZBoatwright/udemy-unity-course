using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

    [SerializeField] int baseHealth = 10;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip explosionSFX;

    private void Start()
    {
        healthText.text = baseHealth.ToString();
    }

    private void OnTriggerEnter()
    {
        baseHealth -= 1;
        healthText.text = baseHealth.ToString();
        GetComponent<AudioSource>().PlayOneShot(explosionSFX);
    }
}
