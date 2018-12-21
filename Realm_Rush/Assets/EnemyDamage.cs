using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Collider collisionMesh;
    [SerializeField] private int hitPoints = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1; /*TODO change the -1 to be a
                                   variable that allows for different damage from different towers*/
        print("Current hitpoints is " + hitPoints);
    }

    private void KillEnemy()
    {
            Destroy(gameObject);
    }
}
