using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	
	[SerializeField] private Waypoint startWaypoint, endWaypoint;

	//Dictionary<Keytype, valuetype>
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	
	private Queue<Waypoint> queue = new Queue<Waypoint>();
	private bool isRunning = true;
	Waypoint searchCenter; //current center during step in search algorithm
	private List<Waypoint> path = new List<Waypoint>(); //TODO make private 

	private Vector2Int[] directions =
	{
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	public List<Waypoint> GetPath()
	{
		LoadBlocks();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
	}
	
	private void LoadBlocks()
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
	
	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.black);
		endWaypoint.SetTopColor(Color.white);
	}

	private void BreadthFirstSearch()
	{
		queue.Enqueue(startWaypoint); //enqueue start node

		while (queue.Count > 0 && isRunning)
		{
			searchCenter = queue.Dequeue();
			HaltIfEndFound();
			ExploreNeighbors();
			searchCenter.IsExplored = true;
		}
	}

	private void HaltIfEndFound()
	{
		if (searchCenter == endWaypoint)
		{
			//halt if reached endpoint
			isRunning = false;
		}
	}

	private void ExploreNeighbors()
	{
		
		foreach (Vector2Int direction in directions)
		{
			Vector2Int exploreCoordinates = direction + searchCenter.GetGridPos();
			try
			{
				QueueNewNeighbors(exploreCoordinates);
			}
			catch
			{
				// do nothing
			}
		}
	}

	private void QueueNewNeighbors(Vector2Int exploreCoordinates)
	{
		Waypoint neighbor = grid[exploreCoordinates];
		if (!neighbor.IsExplored && !queue.Contains(neighbor))
		{
			queue.Enqueue(neighbor);
			neighbor.ExploredFrom = searchCenter; //links together node being added to queue
												  // and the node it was discovered from
		}
	}

	private void CreatePath()
	{
		//temp var currentPoint to traverse path backwards
		Waypoint currentPoint = endWaypoint;
		
		//first add endpoint
		path.Add(currentPoint);
		
		//previous point is the point current node was explored from
		Waypoint previous = endWaypoint.ExploredFrom;

		//add all nodes in between end and start
		while (previous != startWaypoint)
		{
			path.Add(previous);
			currentPoint = previous;
			previous = currentPoint.ExploredFrom;
		}
		
		//add the start point lastly
		path.Add(startWaypoint);
		
		//the list path will need to be reversed
		path.Reverse();

		//colors the path
		foreach (Waypoint node in path)
		{
			node.SetTopColor(Color.blue);
		}
	}
}
