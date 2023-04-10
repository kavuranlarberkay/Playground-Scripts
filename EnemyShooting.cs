using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float shootingRate = 1f;
    private float timeSinceLastShot;
    private Transform playerTransform;
    public Transform gunTransform;
    public GameObject bulletSpawnEnemy;
    public bool canSpawnBullets = true;
   


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gunTransform = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RotateGun();
        ShootPlayer();
        CanShoot();
        
    }

    public void CanShoot()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (GameObject.FindGameObjectWithTag("Player") == null || distanceToPlayer > 35f)
        {
            canSpawnBullets = false;
        }
        else
        {
            canSpawnBullets = true;
        }
    }


    void RotateGun()
    {
        Vector3 vectorToPlayer = playerTransform.position - gunTransform.position;
        float angle = Mathf.Atan2(vectorToPlayer.y, vectorToPlayer.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void ShootPlayer()
    {
        if (canSpawnBullets)
        {
            timeSinceLastShot += Time.deltaTime;

            

            if (timeSinceLastShot >= shootingRate)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnEnemy.transform.position, bulletSpawnEnemy.transform.rotation);
                Vector3 shootDirection = (playerTransform.position - transform.position).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * 30f;
                timeSinceLastShot = 0f;
            }
        }
    }

    
}
