using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrbsStatus
{
    private static bool _blueOrbsCollected = false;
    private static bool _redOrbsCollected = false;
    private static bool _greenOrbsCollected = false;
    private static bool _spikeOrbsCollected = false;
    private static bool _movingOrbsCollected0 = false;
    private static bool _movingOrbsCollected1 = false;
    private static bool _movingOrbsCollected2 = false;
    private static bool _purpleOrbsCollected = false;

    public static bool getStatus(string orbColor)
    {
        bool targetOrb = false;
        if (orbColor == "blue")
        {
            targetOrb = _blueOrbsCollected;
        }
        else if (orbColor == "red")
        {
            targetOrb = _redOrbsCollected;
        }
        else if (orbColor == "green")
        {
            targetOrb = _greenOrbsCollected;
        }
        else if (orbColor == "spike")
        {
            targetOrb = _spikeOrbsCollected;
        }
        else if (orbColor == "moving0")
        {
            targetOrb = _movingOrbsCollected0;
        }
        else if (orbColor == "moving1")
        {
            targetOrb = _movingOrbsCollected1;
        }
        else if (orbColor == "moving2")
        {
            targetOrb = _movingOrbsCollected2;
        }
        else if (orbColor == "purple")
        {
            targetOrb = _purpleOrbsCollected;
        }

        return targetOrb;
    }

    public static void active(string orbColor)
    {
        if (orbColor == "blue")
        {
            _blueOrbsCollected = true;
        }
        else if (orbColor == "red")
        {
            _redOrbsCollected = true;
        }
        else if (orbColor == "green")
        {
            _greenOrbsCollected = true;
        }
        else if (orbColor == "spike")
        {
            _spikeOrbsCollected = true;
        }
        else if (orbColor == "moving0")
        {
            _movingOrbsCollected0 = true;
        }
        else if (orbColor == "moving1")
        {
            _movingOrbsCollected1 = true;
        }
        else if (orbColor == "moving2")
        {
            _movingOrbsCollected2 = true;
        }
        else if (orbColor == "purple")
        {
            _purpleOrbsCollected = true;
        }
    }
}
