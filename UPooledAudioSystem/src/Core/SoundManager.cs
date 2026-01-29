// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

public sealed class SoundManager:MonoBehaviour
{
    internal PoolSystem PoolSystem => poolSystem;
    PoolSystem poolSystem;
    
    AudioSource musicSource;
    AudioSource staticFxSource;
    
    [SerializeField] SoundList sounds;

    void Start()
    {
        musicSource = (new GameObject().AddComponent(typeof(AudioSource)) as AudioSource)!;
        staticFxSource = (new GameObject().AddComponent(typeof(AudioSource)) as AudioSource)!;
        musicSource.transform.SetParent(transform);
        staticFxSource.transform.SetParent(transform);
    }
}