using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // Use this for initialization
    void Start() {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            // loop that divides the distance between the two waypoints and increments the enemies distance between them based on how many seconds is being waited
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}