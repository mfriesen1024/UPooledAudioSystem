// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Core;
using UnityEngine;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util
{
    [RequireComponent(typeof(AudioSource))]
    internal class PooledAudioSource:MonoBehaviour
    {
/*
    SoundManager soundManager => SoundManager.Instance;
*/
    
        bool initialized;

        AudioSource audioSource;
        internal AudioClip Clip;
        internal Action FinishedPlaying;
        internal bool ShouldDestroyOnFinish;

        int ticksLeft;

        internal void Init()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Clip;
            audioSource.Play();

            if (ShouldDestroyOnFinish)
            {
                ticksLeft = (int)Clip.length * 50;
            }
        
            initialized = true;
        }

        void FixedUpdate()
        {
            if (!initialized) return;
            ticksLeft--;

            if (ticksLeft > 0 || audioSource.isPlaying) return;
            FinishedPlaying?.Invoke();
            if (ShouldDestroyOnFinish) Destroy(gameObject);
            else gameObject.SetActive(false);
        }
    }
}