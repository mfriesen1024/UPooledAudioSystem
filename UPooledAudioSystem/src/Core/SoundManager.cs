using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

public sealed class SoundManager:MonoBehaviour
{
    internal PoolSystem PoolSystem => poolSystem;
    PoolSystem poolSystem;

    void Start()
    {
        throw new NotImplementedException();
    }
}