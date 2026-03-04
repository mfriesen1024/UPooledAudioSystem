// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using System;
using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;
using static ca.ScottishDwarfStudio.UPooledAudioSystem.Core.SoundManager;


// Again, this should only compile if we can link to dwarf game.
namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Ext
{
    internal class EventHelper
    {
    SoundList sounds;
    
        public void LinkEvents()
        {
        LoadSounds();
        EventSystem.ButtonPressedNormal += LoadSounds;
        EventSystem.ButtonPressedNormal += ButtonPressedNormal;
        EventSystem.ButtonPressedHeavy += LoadSounds;
        EventSystem.ButtonPressedHeavy += ButtonPressedHeavy;
        EventSystem.ButtonPressedCharacterSelect += LoadSounds;
        EventSystem.ButtonPressedCharacterSelect += ButtonPressedCharacterSelect;

        EventSystem.GameplayStart += LoadSounds;
        EventSystem.GameplayStart += GameplayStart;
        EventSystem.GameplayEnd += LoadSounds;
        EventSystem.GameplayEnd += GameplayEnd;
        EventSystem.GameplayPause += LoadSounds;
        EventSystem.GameplayPause += GameplayPause;
        EventSystem.GameplayResume += LoadSounds;
        EventSystem.GameplayResume += GameplayResume;

        EventSystem.RockHit += LoadSounds;
        EventSystem.RockHit += RockHit;
        EventSystem.RockBreak += LoadSounds;
        EventSystem.RockBreak += RockBreak;

        EventSystem.PlayerMotionUpdate += LoadSounds;
        EventSystem.PlayerMotionUpdate += PlayerMotionUpdate;
        EventSystem.PlayerHit += LoadSounds;
        EventSystem.PlayerHit += PlayerHit;
        EventSystem.PlayerStun += LoadSounds;
        EventSystem.PlayerStun += PlayerStun;
        
        EventSystem.BoxOpened += LoadSounds;
        EventSystem.BoxOpened += BoxOpened;
        EventSystem.BoxClosed += LoadSounds;
        EventSystem.BoxClosed += BoxClosed;
        EventSystem.BoxOreBanked += LoadSounds;
        EventSystem.BoxOreBanked += BoxOreBanked;
        }
    void LoadSounds()
    {
        sounds = Instance?.Sounds;
        if(sounds == null) Debug.LogWarning("Sounds not found, but this might have happened OnValidate. If this happens at runtime its bad.");
    }

    void ButtonPressedNormal()
    {
        Debug.LogException(new NotImplementedException());
    }

    void ButtonPressedHeavy()
    {
        Debug.LogException(new NotImplementedException());
    }

    void ButtonPressedCharacterSelect()
    {
        Debug.LogException(new NotImplementedException());
    }

    void GameplayStart()
    {
        Instance.PlaySound(sounds.gameplayStart);
        Instance.PlaySound(sounds.gameplayMusic);
    }

    void GameplayEnd()
    {
        Instance.PlaySound(sounds.gameplayEnd);
        Instance.PlaySound(sounds.menuMusic);
    }

    void GameplayPause()
    {
        Debug.LogException(new NotImplementedException());
    }

    void GameplayResume()
    {
        Debug.LogException(new NotImplementedException());
    }

    void RockHit()
    {
        Instance.PlaySound(sounds.rockHit);
    }

    void RockBreak()
    {
        Instance.PlaySound(sounds.rockBreak);
    }

    void PlayerMotionUpdate()
    {
        Debug.LogException(new NotImplementedException());
    }

    void PlayerHit()
    {
        Instance.PlaySound(sounds.playerHit);
    }

    void PlayerStun()
    {
        Instance.PlaySound(sounds.playerStun);
    }

    void BoxOpened()
    {
        Instance.PlaySound(sounds.chestOpen);
    }

    void BoxClosed()
    {
        Instance.PlaySound(sounds.chestClose);
    }

    void BoxOreBanked()
    {
        Instance.PlaySound(sounds.chestOreBanked);
    }
    }
}
