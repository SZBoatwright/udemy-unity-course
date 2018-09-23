﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    // public vars are okay in data classes
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] GameObject towerPrefab;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable == true)
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        Instantiate(towerPrefab, transform);
        isPlaceable = false;
    }
}