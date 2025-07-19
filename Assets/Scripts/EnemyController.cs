using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVfx;

    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 5;
    
    ScoreKeeper scoreKeeper;
    Transform parent;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        parent= GameObject.FindGameObjectWithTag("Parent").transform;
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} is hit by {other.gameObject.name}");
        ProcessHit();

        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject hitEffectInstance = Instantiate(hitVfx, transform.position, Quaternion.identity);
        hitEffectInstance.transform.parent = parent.transform;
        hitPoints--;
        scoreKeeper.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        scoreKeeper.IncreaseScore(scorePerHit);
        Destroy(gameObject);
    }
    
    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    
}