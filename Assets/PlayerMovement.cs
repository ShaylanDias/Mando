using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public float runSpeed = 40f;
	public Animator animator;
	public GameObject deathEffect;
	public GameManager gm;
	
	HealthBar healthBar;

	public int maxHealth = 200;
	int health;

	float horizontalMove = 0f;
	bool jump = false;
	bool fly = false;
	int flyCount = 0;
	bool crouch = false;

	void Start() {
		healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
		health = maxHealth;
	}

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("Jumping", true);
			animator.SetBool("HasJumped", true);
		}

		if (Input.GetButton("Jump")) {
			flyCount++;
			if (flyCount > 15) {
					fly = true;
					animator.SetBool("Flying", true);
			}
		} else {
			flyCount = 0;
			fly = false;
			animator.SetBool("Flying", false);
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch")) {
			crouch = false;
		}
	}

	public void OnLanding() {
		animator.SetBool("Jumping", false);
		animator.SetBool("HasJumped", false);
	}

	public void OnFall() {
		animator.SetBool("HasJumped", true);
	}

	public void CrouchChange(bool crouchStatus) {
		animator.SetBool("Crouching", crouchStatus);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, fly);
		jump = false;
	}

	public void TakeDamage(int damage)
	{
			health -= damage;
			if (health <= 0) {
					healthBar.SetHealth(0);
					Die();
			} else {
					healthBar.SetHealth(((float)health)/maxHealth);
			}
	}

	void Die()
	{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			// Destroy(gameObject);
			healthBar.SetHealth(1);
			health = maxHealth;
			gameObject.transform.position = new Vector3(0, 0, 0);
			gm.resetScore();
	}
}
