using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        WalkingEnemy enemy = hitInfo.GetComponent<WalkingEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
    }
}
