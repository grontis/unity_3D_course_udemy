using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
	[FormerlySerializedAs("_path")] [SerializeField] private List<Waypoint> path;
	
	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(FollowPath());
	}

	//IEnumerator return type allows for coroutines
	IEnumerator FollowPath()
	{
		foreach (Waypoint waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f); //yield and returns a wait for 1 second
		}
	}
}
