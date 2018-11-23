using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{

	[SerializeField] private GameObject _deathFx;
	[FormerlySerializedAs("_parent")] [SerializeField] private Transform _fxParent;
	
	
	private void Start()
	{
		Collider nonTriggerCollider = gameObject.AddComponent<BoxCollider>();
		nonTriggerCollider.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(_deathFx, transform.position, Quaternion.identity);
		fx.transform.parent = _fxParent;
		Destroy(gameObject);
		Destroy(fx, 1.5f);
	}
}
