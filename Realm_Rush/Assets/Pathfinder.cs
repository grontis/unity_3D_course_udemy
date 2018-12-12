using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	
	[SerializeField] private Waypoint startWaypoint, endWaypoint;

	//Dictionary<Keytype, valuetype>
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	
	// Use this for initialization
	void Start ()
	{
		LoadBlocks();
		ColorStartAndEnd();
	}

	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.black);
		endWaypoint.SetTopColor(Color.white);
	}

	void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			//find if there are overlapping blocks
			bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
			if (isOverlapping)
			{
				Debug.Log("Overlapping block " + waypoint);
			}
			//add to dictionary
			else
			{
				grid.Add(waypoint.GetGridPos(), waypoint);
			}
		}
	}
	
}
