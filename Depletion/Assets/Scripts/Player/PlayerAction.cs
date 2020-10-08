﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Animator animator;
    public CircleCollider2D boulderCollider;
    public KeyCode mineKey = KeyCode.Space;
    public Collider2D[] colliders;
    private BoulderBreak file;

    // Update is called once per frame
    void Update()
    {
        // Mining
        // If u want, this can be so it only plays the animation once a boulder is in front of the player
        if (Input.GetKeyDown(mineKey)) {
            // plays animation
            animator.SetBool("MineKey", true);
            // get the two diagonal vertices of the player's boxcollider
            Vector3 centre = gameObject.GetComponent<BoxCollider2D>().bounds.center;
            Vector2 radius = gameObject.GetComponent<BoxCollider2D>().size / 2;
            Vector2 pointA = new Vector2(centre.x - radius.x, centre.y + radius.y);
            Vector2 pointB = new Vector2(centre.x + radius.x, centre.y - radius.y);
            // get all colliders overlapping with own
            colliders = Physics2D.OverlapAreaAll(pointA, pointB);
            if (colliders.Length != 0) {
                // go through them until one of them has boulderbreak script
                for (int i=0;i<colliders.Length;++i) {
                    if (colliders[i].gameObject.GetComponent<BoulderBreak>()) {
                        // make boulder change sprite
                        colliders[i].gameObject.GetComponent<BoulderBreak>().breakStage++;
                        // maybe add a 0.5 second cooldown
                        break;
                    }
                }
            }
        }
        if (Input.GetKeyUp(mineKey)) {
            animator.SetBool("MineKey", false);
        }
    }
}
