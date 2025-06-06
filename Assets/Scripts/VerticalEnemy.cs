using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool IsMovingUp = true;
    public float health = 5;

    public float maxHeight = 10f;
    public float minHeight = 0f;
    

    private void Update()
    {
        if (IsMovingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if(transform.position.y >= maxHeight)
                IsMovingUp = false;
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= minHeight)
                IsMovingUp = true;
        }
  
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

            player.Damaged(1);
        }
    }
    public void Damaged(int damageVal)
    {
        health -= damageVal;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
