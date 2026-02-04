// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

internal class PoolSystem:MonoBehaviour
{
    readonly List<PooledAudioSource> pool = new();
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

    internal void PlaySound(PoolableAudioClip clip)
    {
        PooledAudioSource source;
        if (inUseCount < pool.Count)
        {
            source = pool[inUseCount];
            source.gameObject.SetActive(true);
        }

        else
        {
            source = MakeNew();
            if(!deleteUnusedOverflow)pool.Add(source);
        }
        
        source.Clip = clip;
        source.Init();
        inUseCount++;
    }

    PooledAudioSource MakeNew()
    {
        var pooledAudioSource = new GameObject("PooledAudioSource").AddComponent<PooledAudioSource>();
        pooledAudioSource.transform.parent=transform;
        pooledAudioSource.FinishedPlaying += DecrementCounter;
        
        // use >= here because we increment after creation.
        pooledAudioSource.ShouldDestroyOnFinish = inUseCount >= targetPoolSize; 
        return pooledAudioSource;
    }
    
    void DecrementCounter(){inUseCount--;}
}