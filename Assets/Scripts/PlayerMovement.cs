using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float health = 3;
    public float damageCooldown = 3f;
    private float lastDamageTime = -Mathf.Infinity;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 100f;
    private float dashingTime = 1f;
    private float dashingCooldown = 1f;
    public bool didIJustMoveRight = true;
    AudioManager audioManager;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = "health = " + health;
    }

    // Update is called X amount of seconds
    void FixedUpdate()
    {
        // Moving left and Right
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            didIJustMoveRight = true;
        }
        else if (rb.velocity.x < 0)
        {
            didIJustMoveRight = false;
        }

        transform.Rotate(0f, 180f, 0f);

        // Jumping
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioManager.PlaySFX(audioManager.jump);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Damaged(int damageVal)
    // If the last time we took damage is equal to or less than our damage cooldown,
    // we will not take damage and report the damage in the debug log
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            health -= damageVal;
            lastDamageTime = Time.time;
            Debug.Log("took damage: health = " + health);
            healthText.text = "health = " + health;

        }

        Debug.Log("health = " + health);
        // if no health, destroy player
        if (health <= 0)
        {
            healthText.text = "You Died!";
            SceneManager.LoadScene("GameOverScene");
        }
       
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float orginalGravity = rb.gravityScale;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        audioManager.PlaySFX(audioManager.dash);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = orginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
