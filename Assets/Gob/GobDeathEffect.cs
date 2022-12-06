using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobDeathEffect : MonoBehaviour
{
    [SerializeField] private AudioClip[] DeathClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip wilhelm;
    [SerializeField, Range(0, 100)] private int wilhelmPercentChance = 5;

    private void Awake()
    {
        AudioClip deathClip = DeathClips[Random.Range(0, DeathClips.Length)];
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.clip = deathClip;
        audioSource.Play();
        // You know what this is.
        if (Random.Range(0, 101) <= wilhelmPercentChance) audioSource.PlayOneShot(wilhelm);

        Destroy(gameObject, 2.0f);
    }
}
