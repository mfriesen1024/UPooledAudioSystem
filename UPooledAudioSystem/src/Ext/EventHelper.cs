// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util;
using static ca.ScottishDwarfStudio.UPooledAudioSystem.Core.SoundManager;

#if CAN_LINK

// Again, this should only compile if we can link to dwarf game.
namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Ext;

internal class EventHelper
{
    SoundList sounds;
    
    public void LinkEvents()
    {
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
    }

    void LoadSounds()
    {
        sounds = Instance.Sounds;
    }

    void ButtonPressedNormal()
    {
        throw new NotImplementedException();
    }

    void ButtonPressedHeavy()
    {
        throw new NotImplementedException();
    }

    void ButtonPressedCharacterSelect()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    void GameplayResume()
    {
        throw new NotImplementedException();
    }

    void RockHit()
    {
        throw new NotImplementedException();
    }

    void RockBreak()
    {
        throw new NotImplementedException();
    }

    void PlayerMotionUpdate()
    {
        throw new NotImplementedException();
    }

    void PlayerHit()
    {
        throw new NotImplementedException();
    }
}
#endif