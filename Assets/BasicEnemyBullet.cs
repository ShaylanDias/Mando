using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{

    public int damage = 20;
    float moveSpeed = 7f;

    public Rigidbody2D rb;

    PlayerMovement target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerMovement>();
        Vector3 delta = target.transform.position - transform.position;
        moveDirection = (delta).normalized * moveSpeed;
        // Flip to correct initial rotation
        float angle = Vector3.Angle(delta, new Vector3(1f, 0f, 0f));
        transform.Rotate(0f, angle, 0f);
        // Flip to direction of travel
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3.5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player")) {
            col.GetComponent<PlayerMovement>().TakeDamage(damage);
        } else if (col.gameObject.name.Equals("BasicEnemy")) {
            return;
        }
        Destroy(gameObject);
    }
}
