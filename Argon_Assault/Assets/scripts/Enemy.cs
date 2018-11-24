using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{

	[SerializeField] private GameObject _deathFx;
	[FormerlySerializedAs("_parent")] [SerializeField] private Transform _fxParent;
	[SerializeField] private int _scorePerHit = 12;//Enemy is worth this much score
	[FormerlySerializedAs("_hitPoints")] [SerializeField] private int _maxHits = 10;


	private ScoreBoard _scoreboard;
	
	
	private void Start()
	{
		AddBoxCollider();
		_scoreboard = FindObjectOfType<ScoreBoard>(); 
	}

	private void AddBoxCollider()
	{
		Collider nonTriggerCollider = gameObject.AddComponent<BoxCollider>();
		nonTriggerCollider.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		_scoreboard.ScoreHit(_scorePerHit);
		_maxHits--;
		
		//TODO consider hit effects
		if (_maxHits <= 0)
		{
			KillEnemy();
		}
	}

	private void KillEnemy()
	{
		GameObject fx = Instantiate(_deathFx, transform.position, Quaternion.identity);
		fx.transform.parent = _fxParent;
		Destroy(gameObject);
		Destroy(fx, 1.5f);
	}
}
