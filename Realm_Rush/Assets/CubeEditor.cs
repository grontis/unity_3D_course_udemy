using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

[ExecuteInEditMode] //allows for script to run in editor, and not just in game.
[SelectionBase] //allows for selection of parent object with less chance of selecting children
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	private Waypoint waypoint;

	private void Awake()
	{
		waypoint = GetComponent<Waypoint>();
	}

	void Start()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		SnapToGrid();
		UpdateLabel();
	}

	private void SnapToGrid()
	{
		transform.position = new Vector3(
			waypoint.GetGridPos().x, 
			0f, 
			waypoint.GetGridPos().y); //GetGridPos returns a Vector2D, so have to use .y here.
	}

	private void UpdateLabel()
	{
		int gridSize = waypoint.GetGridSize();
		
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string labelText = waypoint.GetGridPos().x / gridSize +
		                   "," + waypoint.GetGridPos().y / gridSize;
		textMesh.text = labelText;
		gameObject.name = "Block " + labelText;
	}
}
