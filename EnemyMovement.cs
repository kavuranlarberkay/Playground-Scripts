using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 10f;
    public float chaseDistance = 5.0f;
    private Transform playerTransform;
    bool canWalk = true;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        WalkToPlayer();
        CanWalkToPlayer();
    }
    
    public void CanWalkToPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            canWalk = false;
        }
    }

    void WalkToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (canWalk)
        {
            if (distanceToPlayer > chaseDistance)
            {
                Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
                transform.Translate(directionToPlayer * enemySpeed * Time.deltaTime);
            }
        }
        
    }
}
