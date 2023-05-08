using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float speed;

    Vector2 movement;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Animating(movement.x, movement.y);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        movement.Normalize();
    }

    void Animating(float _movementX, float _movementY)
    {
        if (_movementX != 0 || _movementY != 0) anim.SetBool("IsWalking", true);
        else anim.SetBool("IsWalking", false);
    }
}
