using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
public class Thruster : MonoBehaviour
{
    TrailRenderer trailRenderer;
    Light thrusterLight;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    private void Start()
    {
        trailRenderer.enabled = false;
        thrusterLight.enabled = false;
        thrusterLight.intensity = 0;
    }

    public void Activeta(bool active = true)
    {
        if (active)
        {
            trailRenderer.enabled = true;
            thrusterLight.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
            thrusterLight.enabled = false;
        }
    }

    public void Intensity( float inten)
    {
        thrusterLight.intensity = inten * 2f;
    }
}
