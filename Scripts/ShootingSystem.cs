﻿using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {
    public float fireRate;
    public int damage;
    public float fieldOfView;
    public bool beam;
    public GameObject projectile;
    public GameObject target;
    public List<GameObject> projectileSpawns;

    List<GameObject> m_lastProjectiles = new List<GameObject>();
    float m_fireTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {
        if (beam && m_lastProjectiles.Count <= 0){
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(transform.position - target.transform.position));

            if(angle < fieldOfView){
                SpawnProjectiles();
            }
            else if(beam && m_lastProjectiles.Count > 0) { }
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(transform.position - target.transform.position));

        if(angle > fieldOfView) {
                while (m_lastProjectiles.Count > 0)
                {
                    Destroy(m_lastProjectiles[0]);
                    m_lastProjectiles.RemoveAt(0);
                }
            }
        }
        else {
            m_fireTimer += Time.deltaTime;

            if(m_fireTimer >= fireRate){
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(transform.position - target.transform.position));

                if (angle < fieldOfView){
                    SpawnProjectiles();

                    m_fireTimer = 0.0f;
                }
            }
        }
	}
    Void SpawnProjectiles(){
        if (!projectile){
            return;
        }

        m_lastProjectiles.clear();
        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i]){
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], target, damage);

                m_lastProjectiles.Add(proj);

            }
        }
    }
}
