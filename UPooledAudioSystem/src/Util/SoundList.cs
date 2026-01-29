// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using UnityEngine;
#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util;

[Serializable]
internal class SoundList
{
    [Header("Music")] object crlf;
    [SerializeField] public AudioClip menuMusic, gameplayMusic;

    [Header("Bla")] object crlf2;
    [SerializeField] public AudioClip rockHit, rockBreak, playerHit, playerStun;
    [SerializeField] public AudioClip chestOpen, chestClose, oreBanked;
    [Header("Bla2")] object crlf3;
    [SerializeField] public AudioClip footstep1;
    [Header("Bla3")] object crlf4;
    [SerializeField] public AudioClip gameplayStart, gameplayEnd, results;
}