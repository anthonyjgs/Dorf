using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobDeathEffect : MonoBehaviour
{
    [SerializeField] private AudioClip[] DeathClips;
    [SerializeField] private AudioSource audioSource;
    private bool playedSound = false;

    private void Awake()
    {
        AudioClip deathClip = DeathClips[Random.Range(0, DeathClips.Length)];
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.clip = deathClip;
    }

    void LateUpdate()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
