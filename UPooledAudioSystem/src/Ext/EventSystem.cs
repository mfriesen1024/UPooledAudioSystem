using System;
using UnityEngine;

/// <summary>
/// Implements eventbus pattern, bla
/// </summary>
public static class EventSystem
{
    // UI events, call when relevant buttons clicked.
    public static Action ButtonPressedNormal;
    public static Action ButtonPressedHeavy;
    public static Action ButtonPressedCharacterSelect; // designer wanted this, so its a thing.

    // Call these when starting/stopping/etc gameplay, used by soundman.
    public static Action GameplayStart;
    public static Action GameplayEnd;
    public static Action GameplayPause;
    public static Action GameplayResume;
        
    // Call these when mining takes place.
    public static Action RockHit;
    public static Action RockBreak;

    // Player events
    public static Action PlayerMotionUpdate; // Call when player's velocity changes
    public static Action PlayerHit; // Call when player is hit.
    public static Action PlayerStun; // Call when a player is stunned.
    
    // Ore box events
    public static Action BoxOpened; // Call when a player is in range of box.
    public static Action BoxClosed; // Call when a player exits range of box.
    public static Action BoxOreBanked; // Call when a piece of ore is banked.
}