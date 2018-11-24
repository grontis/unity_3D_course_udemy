using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{	
	private int _score = 0;
	private Text _scoreText;
	
	// Use this for initialization
	void Start ()
	{
		_scoreText = GetComponent<Text>();
		_scoreText.text = _score.ToString();
	}

	public void ScoreHit(int scorePerHit)
	{
		//ive added some code
		_score = _score + scorePerHit;
		_scoreText.text = _score.ToString();
	}
}
