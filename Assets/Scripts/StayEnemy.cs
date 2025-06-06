using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayEnemy : MonoBehaviour
{
    public GameObject EnemyBullet;
    public Transform bulletPos;

    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2 )
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(EnemyBullet, bulletPos.position, Quaternion.identity);
    }
}
