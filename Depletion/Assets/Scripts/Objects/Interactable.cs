using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    // private MonoBehaviour[] attachedScripts;
    public Sign itemScript; // how do i get access to other script without being specific to each script
    public Transform player;
    public Transform interactableObject;

    // private void Start() {
    //     for (int i=0;i<attachedScripts.Length;++i) {
    //         if (attachedScripts[i].dialogue != null) {
    //             Debug.Log(attachedScripts[i]);
    //             itemScript = attachedScripts[i];
    //         }
    //     }
    // }

    public void Interact()
    {
        Debug.Log("Interacted");
        // check if theres player within radius
        float distance = Vector3.Distance(player.position, interactableObject.position);
        Debug.Log(distance + " - " + radius);
        if (distance <= radius) {  // how to create new instance of class interactable - it stays with the first one idk
            Debug.Log("Before activated");
            itemScript.Activate();
        }
    }
}
