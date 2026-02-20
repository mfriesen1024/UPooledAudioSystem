// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using UnityEngine;
#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util;

[Serializable]
public sealed class SoundList
{
    // TODO: convert to readonly.
    [Header("Music")] object crlf;
    [SerializeField] public PoolableAudioClip menuMusic, gameplayMusic;

    [Header("UI")] object crlf2;
    [SerializeField] public PoolableAudioClip buttonNormal, buttonHeavy, buttonCharacterSelected;
    [Header("Gameplay")] object crlf3;
    [SerializeField] public PoolableAudioClip rockHit, rockBreak;
    [SerializeField] public PoolableAudioClip playerHit, playerStun, playerFootstep1;
    [SerializeField] public PoolableAudioClip chestOpen, chestClose, chestOreBanked;
    [Header("Game State")] object crlf4;
    [SerializeField] public PoolableAudioClip gameplayStart, gameplayEnd, results;
}