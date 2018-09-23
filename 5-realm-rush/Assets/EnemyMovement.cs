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
            Vector3 moveIncrement = (waypoint.transform.position - gameObject.transform.position) / waypointDistance;
            bool isEnemyDead = GetComponent<EnemyDamage>().isEnemyDead();

            for (int i = 0; i < waypointDistance && !isEnemyDead; i++)
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