﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public static Loading Instance = new Loading();
    private AsyncOperation currentLoadingOperation;
    public GameObject loadingScreenCanvas;
    private bool isLoading;
    [SerializeField]
    public GameObject percentage;
    public Text percentLoadedText;
    private const float minShowingTime = 1f;
    private float timeElapsed;
    public Animator animator;
    private bool didTriggerFadeOutAnimation;

    public void setVars(Text percentText, Animator animatorObject)
    {
        percentLoadedText = percentText;
        animator = animatorObject;
    }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        // animator = GetComponent<Animator>();
        // percentLoadedText = GetComponent<Text>();
        Hide();
    }
    private void Update()
    {
        if (isLoading)
        {
            SetProgress(currentLoadingOperation.progress);
            // If the loading is complete, hide the loading screen:
            if (currentLoadingOperation.isDone && !didTriggerFadeOutAnimation) {
                animator.SetTrigger("Hide");
                didTriggerFadeOutAnimation = true;
            } else {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= minShowingTime) {
                    // The loading screen has been showing for the minimum time required.
                    // Allow the loading operation to finish:
                    currentLoadingOperation.allowSceneActivation = true;
                }
            }
        }
    }
    // Updates the UI based on the progress:
    private void SetProgress(float progress)
    {
        // Set the percent loaded text:
        percentLoadedText.text = Mathf.CeilToInt(progress * 100).ToString() + "%";
    }
    // Call this to show the loading screen.
    // We can determine the loading's progress when needed from the AsyncOperation param:
    public void Show(AsyncOperation loadingOperation) // also get scene name, i want for the scene name to show at the bottom left corner
    {
        Debug.Log("log 2");
        currentLoadingOperation = loadingOperation;
        currentLoadingOperation.allowSceneActivation = false;
        SetProgress(0f);
        timeElapsed = 0f;
        animator.SetTrigger("Show");
        didTriggerFadeOutAnimation = false;
        isLoading = true;
    }
    public void Hide()
    {
        currentLoadingOperation = null;
        isLoading = false;
        loadingScreenCanvas.SetActive(false);
    }
}
