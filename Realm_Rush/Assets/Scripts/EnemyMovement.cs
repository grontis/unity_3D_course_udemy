using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
		List<Waypoint> path = pathfinder.GetPath();
		StartCoroutine(FollowPath(path));
	}


	//IEnumerator return type allows for coroutines
	IEnumerator FollowPath(List<Waypoint> path)
	{
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f); //yield and returns a wait for 1 second
		}
	}
}
