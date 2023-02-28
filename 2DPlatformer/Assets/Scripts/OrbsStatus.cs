using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrbsStatus
{
    private static bool _blueOrbsCollected = false;
    private static bool _redOrbsCollected = false;
    private static bool _greenOrbsCollected = false;
    private static bool _spikeOrbsCollected = false;
    private static bool _movingOrbsCollected = false;

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
        else if (orbColor == "moving")
        {
            targetOrb = _movingOrbsCollected;
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
        else if (orbColor == "moving")
        {
            _movingOrbsCollected = true;
        }
    }
}
