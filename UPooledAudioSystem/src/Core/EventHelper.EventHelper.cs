// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

#if CAN_LINK

// Again, this should only compile if we can link to dwarf game.
namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

internal class EventHelper
{
    public void LinkEvents()
    {
        EventSystem.ButtonPressedNormal += ButtonPressedNormal;
        EventSystem.ButtonPressedHeavy += ButtonPressedHeavy;
        EventSystem.ButtonPressedCharacterSelect += ButtonPressedCharacterSelect;
        
        EventSystem.GameplayStart += GameplayStart;
        EventSystem.GameplayEnd += GameplayEnd;
        EventSystem.GameplayPause += GameplayPause;
        EventSystem.GameplayResume += GameplayResume;
        
        EventSystem.RockHit += RockHit;
        EventSystem.RockBreak += RockBreak;
        
        EventSystem.PlayerMotionUpdate += PlayerMotionUpdate;
        EventSystem.PlayerHit += PlayerHit;
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
        throw new NotImplementedException();
    }

    void GameplayEnd()
    {
        throw new NotImplementedException();
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