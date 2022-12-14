using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePitchWithTime : MonoBehaviour
{
    private AudioSource audioSource;
    private float basePitch = 1.0f;
    private float targetPitch = 1.0f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        basePitch = audioSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        targetPitch = basePitch * Time.timeScale;
        targetPitch = Mathf.Clamp(targetPitch, basePitch/2, basePitch*2);
        audioSource.pitch = targetPitch;
    }
}
