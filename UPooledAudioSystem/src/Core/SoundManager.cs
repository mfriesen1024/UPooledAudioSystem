// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

public sealed class SoundManager:MonoBehaviour
{
    public static SoundManager Instance => instance;
    static SoundManager instance;
    internal PoolSystem PoolSystem => poolSystem;
    PoolSystem poolSystem;
    
    AudioSource musicSource;
    AudioSource staticFxSource;

#pragma warning disable CS0169 // Field is never used
    [Header("Performance")] object crlf;
#pragma warning restore CS0169 // Field is never used
    [SerializeField] int poolSize = 10;
    [SerializeField] bool deleteUnusedOverflow=true; 

#pragma warning disable CS0169 // Field is never used
    [Header("Sound Data")] object crlf2;
#pragma warning restore CS0169 // Field is never used
    [SerializeField] SoundList sounds = new();

    void Start()
    {
        instance = this;
        
        musicSource = (new GameObject("MusicSource").AddComponent(typeof(AudioSource)) as AudioSource)!;
        staticFxSource = (new GameObject("StaticFXSource").AddComponent(typeof(AudioSource)) as AudioSource)!;
        musicSource.transform.SetParent(transform);
        staticFxSource.transform.SetParent(transform);

        poolSystem = (new GameObject("PooledSources").AddComponent(typeof(PoolSystem)) as PoolSystem)!;
        poolSystem.transform.SetParent(transform);
        poolSystem.Init(poolSize, deleteUnusedOverflow);
    }
}