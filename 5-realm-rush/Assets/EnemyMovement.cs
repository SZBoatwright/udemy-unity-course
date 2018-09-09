using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

    // Use this for initialization
    void Start() {
        //StartCoroutine(FollowPath());
	}

    IEnumerator FollowPath()
    {
        print("Starting patroll");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting waypoint " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1);
        }
        print("Ending patroll");
    }


    // Update is called once per frame
    void Update () {
		
	}
}