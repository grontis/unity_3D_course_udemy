using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

	//Dictionary<Keytype, valuetype>
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	
	// Use this for initialization
	void Start ()
	{
		LoadBlocks();
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
				waypoint.SetTopColor(Color.red);
			}
		}
		print(grid.Count + " blocks added to dictionary");
	}
	
}
