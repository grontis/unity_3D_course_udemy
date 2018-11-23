using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //remember, you only want 1 script to handle scene management

public class CollisionHandler : MonoBehaviour
{

	[Tooltip("In seconds")][SerializeField] private float _levelLoadDelay = 1f;

	[Tooltip("Particle FX prefab on player")][SerializeField] GameObject _deathFx;
	
	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
		_deathFx.SetActive(true);
		Invoke("ReloadScene", _levelLoadDelay);
	}

	private void StartDeathSequence()
	{
		SendMessage("OnPlayerDeath");
		
	}

	//method name is string referenced in OnTriggerEnter function
	private void ReloadScene()
	{
		SceneManager.LoadScene(1);
	}

}
