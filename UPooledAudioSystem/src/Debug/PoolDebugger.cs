// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Core;
using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Debug;

// This is effectively a unit test for the pooling system.
[RequireComponent(typeof(SoundManager))]
internal class PoolDebugger:MonoBehaviour
{
    [SerializeField] SoundList bla;
    [SerializeField] SoundManager soundManager;
    
    void Start()
    {
        soundManager ??= GetComponent<SoundManager>();
        soundManager.Sounds = bla;

        try
        {
            PlayerTest();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Base player unit test failed. See exception below.");
            UnityEngine.Debug.LogException(e);
        }

        try
        {
            PoolTest();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Pool unit test failed. See exception below.");
            UnityEngine.Debug.LogException(e);
        }
    }

    void PlayerTest()
    {
        soundManager.PlaySound(bla.menuMusic);
        soundManager.PlaySound(bla.chestClose);
        soundManager.PlaySound(bla.playerHit);
    }

    void PoolTest()
    {
        for (int i = 0; i < 100; i++)
        {
            soundManager.PlaySound(bla.playerHit);
        }
    }
}