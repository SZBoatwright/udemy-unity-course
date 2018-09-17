using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    [SerializeField] GameObject pivotObject;
    [SerializeField] GameObject lookAtTarget;
	
	// Update is called once per frame
	void Update () {
        pivotObject.transform.LookAt(lookAtTarget.transform);
	}
}
