﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Waypoint : MonoBehaviour {
	
	const int gridSize = 10;
	private Vector2Int gridPos;

	public bool IsExplored = false; //explored property for BFS algorithm
	public Waypoint ExploredFrom;
	
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
		//set top surface color of block
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;
	}
}
