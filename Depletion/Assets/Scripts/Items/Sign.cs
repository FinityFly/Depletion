using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject textObject;
    private string[] dialogue = { "Lorem", "Ipsum", "Text" };
    public GameObject signCanvas;
    public static bool isActivated = false;
    public PlayerMovement pm;
    public Animator animator;
    public static int count = 0;

    public void Activate() {
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
