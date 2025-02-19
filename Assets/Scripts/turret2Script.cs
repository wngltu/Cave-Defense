﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret2Script : MonoBehaviour
{
    public Transform currentTarget;
    public Transform rotationPart;
    public Transform muzzle;

    public float sightRange = 15f;

    public string enemyTag = "enemytarget";

    public float fireRate = 3;
    private float fireTimer = 0;

    public GameObject bullet2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
        Destroy(gameObject, 60f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= sightRange)
        {
            currentTarget = nearestEnemy.transform;
        }
        else
        {
            currentTarget = null;
        }
    }
    private void Update()
    {
        if (currentTarget == null)
            return;

        Vector3 dir = currentTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0, rotation.y, 0);

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            shoot();
            fireTimer = 3;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
    }
    void shoot()
    {
        GameObject bulletShoot = (GameObject)Instantiate(bullet2, muzzle.position, muzzle.rotation);
        bullet2Script bullet = bulletShoot.GetComponent<bullet2Script>();

        if (bullet != null)
        {
            bullet.seekTarget(currentTarget);
        }
    }

}