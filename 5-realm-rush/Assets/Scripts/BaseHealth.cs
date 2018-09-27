using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

    [SerializeField] int baseHealth = 10;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = baseHealth.ToString();
    }

    private void OnTriggerEnter()
    {
        print("collision");
        baseHealth -= 1;
        healthText.text = baseHealth.ToString();
    }
}
