using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject textObject;
    public string[] dialogue = {"Null"};
    public GameObject signCanvas;
    public static bool isActivated = false;
    public PlayerMovement pm;
    public Animator animator;
    public static int count = 0;

    // public float radius = 2f;
    // // private MonoBehaviour[] attachedScripts;
    // public Sign itemScript; // how do i get access to other script without being specific to each script
    // public Transform player;

    // public void Interact()
    // {
    //     Debug.Log("Interacted");
    //     // check if theres player within radius
    //     float distance = Vector3.Distance(player.position, transform.position);
    //     Debug.Log(distance + " - " + radius);
    //     if (distance <= radius) {
    //         Debug.Log("Before activated");
    //         itemScript.Activate();
    //     }
    // }

    public void Activate() {
        Debug.Log("Activated");
        if (count == 0) {
            signCanvas.SetActive(true);
            pm.canMove = false;
            animator.SetFloat("Speed", 0f);
        }
        if (count < dialogue.Length) {
            textObject.GetComponent<Text>().text = dialogue[count];
            ++count;
        } else if (count == dialogue.Length) {
            Deactivate();
        }
    }

    private void Deactivate() {
        signCanvas.SetActive(false);
        pm.canMove = true;
        animator.SetFloat("Speed", 0f);
        count = 0;
    }
}
