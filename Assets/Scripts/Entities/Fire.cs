﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject firePoint, fireBullet;

    [SerializeField]
    float fireRate = 0.5f;

    float lastFired = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && (Time.time - lastFired > fireRate))
        {
            GameObject bullet = Instantiate(fireBullet, firePoint.transform.position, Quaternion.identity);
            Vector3 point;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {
                point = hit.point;
            }
            else
            {
                point = ray.GetPoint(100f);
            }

            bullet.transform.LookAt(point);

            BulletFire bulletFire = bullet.GetComponent<BulletFire>();
            bulletFire.destination = point;
            bulletFire.player = gameObject;
            bulletFire.Fire();

            lastFired = Time.time;
        }
    }
}
