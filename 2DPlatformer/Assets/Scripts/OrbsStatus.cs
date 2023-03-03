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

    public static bool levelOneComplete()
    {
        return _spikeOrbsCollected;
    }

    public static void levelOnePrep()
    {
        _blueOrbsCollected = false;
        _redOrbsCollected = false;
        _greenOrbsCollected = false;
        _spikeOrbsCollected = false;
        _movingOrbsCollected0 = false;
        _movingOrbsCollected1 = false;
        _movingOrbsCollected2 = false;
        _purpleOrbsCollected = false;
    }

    public static bool levelTwoComplete()
    {
        return _spikeOrbsCollected && _movingOrbsCollected0 &&
               _movingOrbsCollected1 && _movingOrbsCollected2;
    }

    public static void levelTwoPrep()
    {
        _blueOrbsCollected = false;
        _redOrbsCollected = false;
        _greenOrbsCollected = false;
        _spikeOrbsCollected = true;
        _movingOrbsCollected0 = false;
        _movingOrbsCollected1 = false;
        _movingOrbsCollected2 = false;
        _purpleOrbsCollected = false;
    }

    public static bool levelThreeComplete()
    {
        return _spikeOrbsCollected && _movingOrbsCollected0 &&
               _movingOrbsCollected1 && _movingOrbsCollected2 && _purpleOrbsCollected;
    }

    public static void levelThreePrep()
    {
        _blueOrbsCollected = false;
        _redOrbsCollected = false;
        _greenOrbsCollected = false;
        _spikeOrbsCollected = true;
        _movingOrbsCollected0 = true;
        _movingOrbsCollected1 = true;
        _movingOrbsCollected2 = true;
        _purpleOrbsCollected = false;
    }

    public static bool levelFourComplete()
    {
        return _spikeOrbsCollected && _movingOrbsCollected0 &&
               _movingOrbsCollected1 && _movingOrbsCollected2 &&
               _purpleOrbsCollected && _blueOrbsCollected;
    }

    public static void levelFourPrep()
    {
        _blueOrbsCollected = false;
        _redOrbsCollected = false;
        _greenOrbsCollected = false;
        _spikeOrbsCollected = true;
        _movingOrbsCollected0 = true;
        _movingOrbsCollected1 = true;
        _movingOrbsCollected2 = true;
        _purpleOrbsCollected = true;
    }
}
