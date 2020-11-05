using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.5f;
    public Sign itemScript; // how do i get access to other script without being specific to each script
    public static bool isInteracted = false;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (isInteracted) {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) {
                itemScript.isActivated = true;
            }
        } else {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) {
                itemScript.isActivated = false;
            }
        }
    }
}
