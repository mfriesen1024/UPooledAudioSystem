// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

public sealed class SoundManager:MonoBehaviour
{
    public static SoundManager Instance => instance;
    static SoundManager instance;
    internal PoolSystem PoolSystem => poolSystem;
    PoolSystem poolSystem;
    
    AudioSource musicSource;
    AudioSource staticFxSource;

    [Header("Performance")] object crlf;
    [SerializeField] int poolSize = 10;
    [SerializeField] bool deleteUnusedOverflow=true; 

    [Header("Sound Data")] object crlf2;
    [SerializeField] SoundList sounds;

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