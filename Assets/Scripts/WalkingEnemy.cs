using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkingEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool IsMovingRight = true;
    public int health = 5;
    public int EnemyType;

  
    private void Update()
    {
        if (EnemyType == 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
            if (!groundInfo.collider)
            {
                Debug.Log("check");
                Flip();
            }
        }
       
    }

    void Flip()
    {
        IsMovingRight = !IsMovingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        moveSpeed *= -1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

            player.Damaged(1);
        }
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
