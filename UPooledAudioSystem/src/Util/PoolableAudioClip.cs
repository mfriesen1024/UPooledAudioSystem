// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using UnityEngine;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util;

[Serializable]
public sealed class PoolableAudioClip
{
    [SerializeField] internal AudioClip Clip = null!;
    [Tooltip("This isn't implemented yet.")] // TODO: implement individual sound volume modifiers.
    public float VolumeMultiplier = 1;
    public AudioTags.Tag tag = AudioTags.Tag.Default;
    
    internal string StringTag => AudioTags.TagToString(tag);
    
    public static implicit operator AudioClip(PoolableAudioClip clip) => clip.Clip;
}