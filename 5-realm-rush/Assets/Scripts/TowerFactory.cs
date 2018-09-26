using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int maxTowers;
    [SerializeField] FireAtEnemy towerPrefab;
    [SerializeField] GameObject towerParent;

    Queue<FireAtEnemy> towers = new Queue<FireAtEnemy>();

	public void AddTower (Waypoint baseWaypoint) 
    {
        int numTowers = towers.Count;

        if(numTowers < maxTowers)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        FireAtEnemy newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        newTower.transform.parent = towerParent.transform;

        towers.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        FireAtEnemy removedTower = towers.Dequeue();
        towers.Enqueue(removedTower);
        removedTower.baseWaypoint.isPlaceable = true;

        baseWaypoint.isPlaceable = false;
        removedTower.baseWaypoint = baseWaypoint;
        removedTower.transform.position = baseWaypoint.transform.position;
    }
}
