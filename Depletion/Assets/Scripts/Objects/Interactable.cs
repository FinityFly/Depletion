using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.5f;
    // private MonoBehaviour[] attachedScripts;
    public Sign itemScript; // how do i get access to other script without being specific to each script
    public Transform player;

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
        // check if theres player within radius
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius) {
            itemScript.Activate();
        }
    }
}
