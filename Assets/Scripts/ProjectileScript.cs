using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    AudioManager audioManager;

    public Vector3 shootOffset = new Vector3(2, 0, 0);

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerMovement.didIJustMoveRight)
            {
                shootOffset = new Vector3(2, 0, 0);
            }
            else
            {
                shootOffset = new Vector3(-2, 0, 0);
            }
            GameObject projectile = Instantiate(projectilePrefab, transform.position + shootOffset, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            
            if(playerMovement.didIJustMoveRight)
            {
                rb.velocity = new Vector3(projectileSpeed, 0, 0);
            }
            else
            {
                rb.velocity = new Vector3(-projectileSpeed, 0, 0);
            }

            
            audioManager.PlaySFX(audioManager.shoot);
        }
    }
     
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
