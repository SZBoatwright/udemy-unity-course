using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour {
    
    Waypoint waypoint;

    int gridSize;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        gridSize = waypoint.GetGridSize();
    }

    void Update () {

        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid ()
    {
        transform.position = new Vector3(
            waypoint.GetGridPos().x, 
            0f, 
            waypoint.GetGridPos().y
        );
    }
    
    private void UpdateLabel()
    {
        string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
