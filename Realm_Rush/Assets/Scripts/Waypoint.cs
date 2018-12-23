using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Waypoint : MonoBehaviour {
	
	const int GridSize = 10;
	private Vector2Int gridPos;

	[FormerlySerializedAs("IsExplored")] public bool isExplored = false; //explored property for BFS algorithm
	[FormerlySerializedAs("ExploredFrom")] public Waypoint exploredFrom;
	public bool isPlaceable = true;
	
	public int GetGridSize()
	{
		return GridSize;
	}

	void Start()
	{
		Physics.queriesHitTriggers = true;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / GridSize),
			Mathf.RoundToInt(transform.position.z / GridSize)
			);
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (isPlaceable)
			{
				print(gameObject.name + " tower placement");
			}
			else
			{
				print("Cant place tower here");
			}
		}
	}
	
}
