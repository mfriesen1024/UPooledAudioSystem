// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

internal class PoolSystem:MonoBehaviour
{
    List<PooledAudioSource> pool;
    int targetPoolSize;
    int inUseCount;
    bool deleteUnusedOverflow;
    
    internal void Init(int poolSize, bool deleteUnusedOverflow)
    {
        targetPoolSize = poolSize;
        this.deleteUnusedOverflow = deleteUnusedOverflow;

        for (int i = 0; i < targetPoolSize; i++)
        {
            pool.Add(MakeNew());
        }
    }

    void PlaySound(AudioClip clip)
    {
        PooledAudioSource source;
        if (inUseCount < pool.Count)
        {
            source = pool[inUseCount];
        }

        else
        {
            source = MakeNew();
            if(!deleteUnusedOverflow)pool.Add(source);
        }
        
        source.clip = clip;
        source.Init();
        inUseCount++;
    }

    PooledAudioSource MakeNew()
    {
        var pooledAudioSource = new GameObject().AddComponent<PooledAudioSource>();
        pooledAudioSource.transform.parent=transform;
        pooledAudioSource.FinishedPlaying += DecrementCounter;
        return pooledAudioSource;
    }
    
    void DecrementCounter(){inUseCount--;}
}