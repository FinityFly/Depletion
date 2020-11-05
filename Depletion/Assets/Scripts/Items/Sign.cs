using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject textObject;
    public string text = "No text assigned";
    public GameObject signCanvas;
    public bool isActivated = false;
    private bool currentlyActivated = false;
    public PlayerMovement pm;
    public Animator animator;

    private void Activate() {
        currentlyActivated = true;
        signCanvas.SetActive(true);
        pm.canMove = false;
        animator.SetFloat("Speed", 0f);
    }

    private void Deactivate() {
        currentlyActivated = false;
        signCanvas.SetActive(false);
        pm.canMove = true;
        animator.SetFloat("Speed", 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        textObject.GetComponent<Text>().text = text;
        if (isActivated) {
            Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated && currentlyActivated == false) {
            Activate();
        } else if (isActivated == false) {
            Deactivate();
        }
    }
}
