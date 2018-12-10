using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

[ExecuteInEditMode] //allows for script to run in editor, and not just in game.
[SelectionBase] //allows for selection of parent object with less chance of selecting children
public class CubeEditor : MonoBehaviour
{
	[SerializeField][Range(1f, 20f)] private float _gridSize = 10f;


	private TextMesh _textMesh;

	void Start()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 snapPos;
		
		snapPos.x = Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize;
		snapPos.z = Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize;
		transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
		
		
		_textMesh = GetComponentInChildren<TextMesh>();
		string labelText = snapPos.x / _gridSize + "," + snapPos.z / _gridSize;
		_textMesh.text = labelText;
		gameObject.name = "Block " + labelText;

	}
}
