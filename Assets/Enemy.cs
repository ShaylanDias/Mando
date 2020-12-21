using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deathEffect;

    public Transform firePoint;

    public Animator animator;

    [SerializeField]
    GameObject bullet;

    private PlayerMovement player;

    private float fireRate = 2f;
    private float nextFire;
    private float shootAnimationDuration = 0.4f;
    private float timeFiring;
    
    private bool facingRight = false;  // For determining which way the player is currently facing.

    void Start() {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        nextFire = Time.time;
    }

    private void Update() {
        CheckAndFire();
        CheckDirection();
    }

    void CheckDirection() {
        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();
        else if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();
    }

    void CheckAndFire() {
        if (Time.time > nextFire) {
            animator.Play("BasicEnemy_Shoot");
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
            timeFiring = Time.time + shootAnimationDuration;
        }
        if (Time.time > timeFiring) {
            animator.Play("Idle");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);
	}

}