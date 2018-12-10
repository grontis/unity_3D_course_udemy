using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	[SerializeField] private List<Block> _path;


	
	// Use this for initialization
	void Start ()
	{
		PrintAllWaypoints();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	
	private void PrintAllWaypoints()
	{
		foreach (Block waypoint in _path)
		{
			print(waypoint.name);
		}
	}
}
