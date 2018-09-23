using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // params
    [SerializeField] int movementSmoothness = 3;
    [SerializeField] float movementSpeed = 0.001f;

    float waypointDistance;

    void Start() {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();

        var path = pathFinder.GetPath();
        waypointDistance = Vector3.Distance(path[0].transform.position, path[1].transform.position) * movementSmoothness;

        StartCoroutine(FollowPath(path, waypointDistance));
	}

    IEnumerator FollowPath(List<Waypoint> path, float waypointDistance)
    {
        foreach (Waypoint waypoint in path)
        {
            //transform.position = waypoint.transform.position;
            // loop that divides the distance between the two waypoints and increments the enemies distance between them based on how many seconds is being waited
            Vector3 moveIncrement = (waypoint.transform.position - gameObject.transform.position) / waypointDistance;

            for (int i = 0; i < waypointDistance; i++)
            {
                transform.position = gameObject.transform.position + moveIncrement;
                yield return new WaitForSeconds(movementSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}