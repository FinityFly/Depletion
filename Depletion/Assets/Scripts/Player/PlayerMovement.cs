using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement, lastDirection;
    // link to options variables when its done
    public KeyCode upKey = KeyCode.W, downKey = KeyCode.S, rightKey = KeyCode.D, leftKey = KeyCode.A;
    // my plan is to have a dictionary of all the custom keybinds instead of this temporary thing, like with movement, interact, attack, etc.
    // it's more organized
    // public Dictionary<string, int> keyBinds = new Dictionary<string, int>();
    // ^ initialize when game/scene start or smth

	void Update()
    {
        // getting user input
        if (Input.GetKey(rightKey) && !Input.GetKey(leftKey)) {
            movement.x = 1;
            lastDirection.x = 1;
            lastDirection.y = 0;
        } else if (Input.GetKey(leftKey) && !Input.GetKey(rightKey)) {
            movement.x = -1;
            lastDirection.x = -1;
            lastDirection.y = 0;
        } else {
            movement.x = 0;
        }
        if (Input.GetKey(upKey) && !Input.GetKey(downKey)) {
            movement.y = 1;
            lastDirection.y = 1;
            lastDirection.x = 0;
        } else if (Input.GetKey(downKey) && !Input.GetKey(upKey)) {
            movement.y = -1;
            lastDirection.y = -1;
            lastDirection.x = 0;
        } else {
            movement.y = 0;
        }
        // sends data to player animator to play the right animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("LastHorizontal", lastDirection.x);
        animator.SetFloat("LastVertical", lastDirection.y);
    }

    void FixedUpdate()
    {
        // actually moving the player
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
