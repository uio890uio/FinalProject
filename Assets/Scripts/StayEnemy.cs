using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayEnemy : MonoBehaviour
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public GameObject EnemyBullet;
    public Transform bulletPos;
    private GameObject player;
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 15)
        {
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
        
    }
    void shoot()
    {
        Instantiate(EnemyBullet, bulletPos.position, Quaternion.identity);
    }
   
}
