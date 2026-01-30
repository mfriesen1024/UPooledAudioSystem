// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Core;
using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util;

[RequireComponent(typeof(AudioSource))]
internal class PooledAudioSource:MonoBehaviour
{
    SoundManager soundManager => SoundManager.Instance;
    
    bool initialized;
    
    internal AudioSource audioSource;
    internal AudioClip clip;
    internal Action FinishedPlaying;
    internal bool shouldDestroyOnFinish;

    int ticksLeft;

    internal void Init()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        if (shouldDestroyOnFinish)
        {
            ticksLeft = (int)clip.length * 50;
        }
        
        initialized = true;
    }

    void FixedUpdate()
    {
        if (!initialized) return;
        ticksLeft--;

        if (ticksLeft > 0 || audioSource.isPlaying) return;
        FinishedPlaying?.Invoke();
        if (shouldDestroyOnFinish) Destroy(gameObject);
        else gameObject.SetActive(false);
    }
}