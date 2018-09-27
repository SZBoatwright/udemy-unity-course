using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour {

    [SerializeField] int baseHealth = 10;

    private void OnTriggerEnter()
    {
        print("collision");
        baseHealth -= 1;
    }
}
