// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using UnityEngine;
using static ca.ScottishDwarfStudio.UPooledAudioSystem.Core.SoundManager;


// Again, this should only compile if we can link to dwarf game.
namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Ext;

internal class EventHelper
{
    #if CAN_LINK
    SoundList sounds;
    #endif
    
    public void LinkEvents()
    {
        #if CAN_LINK
        LoadSounds();
        EventSystem.ButtonPressedNormal += LoadSounds + ButtonPressedNormal;
        EventSystem.ButtonPressedHeavy += LoadSounds + ButtonPressedHeavy;
        EventSystem.ButtonPressedCharacterSelect += LoadSounds + ButtonPressedCharacterSelect;
        
        EventSystem.GameplayStart += LoadSounds + GameplayStart;
        EventSystem.GameplayEnd += LoadSounds + GameplayEnd;
        EventSystem.GameplayPause += LoadSounds + GameplayPause;
        EventSystem.GameplayResume += LoadSounds + GameplayResume;
        
        EventSystem.RockHit += LoadSounds + RockHit;
        EventSystem.RockBreak += LoadSounds + RockBreak;
        
        EventSystem.PlayerMotionUpdate += LoadSounds + PlayerMotionUpdate;
        EventSystem.PlayerHit += LoadSounds + PlayerHit;
        #endif
    }

#if CAN_LINK
    void LoadSounds()
    {
        sounds = Instance.Sounds;
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
#endif
}
