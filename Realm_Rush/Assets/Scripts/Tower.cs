using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private ParticleSystem projectileParticle;

    //State of each tower
    Transform targetEnemy;

    
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) {return;}

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    Transform GetClosestEnemy(Transform a, Transform b)
    {
        var distToA = Vector3.Distance(transform.position, a.position);
        var distToB = Vector3.Distance(transform.position, b.position);
        
        if(distToA < distToB)
        {
            return a;
        }
        return b;

    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position
                                , gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive; //if isActive the emission of particles is enabled
    }
    
}
