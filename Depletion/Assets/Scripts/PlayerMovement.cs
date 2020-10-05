using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    // link to options variables when its done
    public KeyCode upKey, downKey, rightKey, leftKey;
    // my plan is to have a dictionary of all the custom keybinds instead of this temporary thing, like with movement, interact, attack, etc.
    // it's more organized
    // public Dictionary<string, int> keyBinds = new Dictionary<string, int>();
    // ^ initialize when game/scene start or smth


	void Update()
    {
        // getting user input
        if (Input.GetKeyDown(upKey))
            ++movement.x;
        if (Input.GetKeyDown(downKey))
            --movement.x;
        if (Input.GetKeyDown(rightKey))
            ++movement.y;
        if (Input.GetKeyDown(leftKey))
            --movement.y;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        // actually moving the rb
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
