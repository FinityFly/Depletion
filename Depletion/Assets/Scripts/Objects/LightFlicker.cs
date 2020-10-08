using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    private Light2D lightComponent;
    // depending on light source, change these values
    public float minIntensity = 3.4f;
    public float maxIntensity = 3.6f;
    public float speed = 0.02f;

    private bool isDimming = false;

    void Start() {
        // get light 2d component
        lightComponent = GetComponent<Light2D>();
        speed *= 0.06f;
    }

    void Update()
    {
        // maybe add a random element to it - i dont want to attract too much attention to it tho
        if (isDimming) {
            if (lightComponent.pointLightOuterRadius > minIntensity) {
                lightComponent.pointLightOuterRadius -= speed + Random.Range(0, speed * 0.4f);
            } else {
                isDimming = false;
                lightComponent.pointLightOuterRadius += speed + Random.Range(0, speed * 0.4f);
            }
        } else {
            if (lightComponent.pointLightOuterRadius < maxIntensity) {
                lightComponent.pointLightOuterRadius += speed + Random.Range(0, speed * 0.4f);
            } else {
                isDimming = true;
                lightComponent.pointLightOuterRadius -= speed + Random.Range(0, speed * 0.4f);
            }
        }
    }
}

