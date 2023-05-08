using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    Animator anim;
    Vector2 movement;

    [SerializeField] private float initAngle;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - initAngle;
        rb.rotation = -angle;
        direction.Normalize();
        movement = direction;

        Animating(movement.x, movement.y);
    }

    private void FixedUpdate()
    {
        Move(movement);
    }

    void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        //direction.Normalize();
    }

    void Animating(float _movementX, float _movementY)
    {
        if (_movementX != 0 || _movementY != 0) anim.SetBool("IsMoving", true);
        else anim.SetBool("IsMoving", false);
    }
}
