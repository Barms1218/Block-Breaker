using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectsUtils
{
    #region Fields

    static SpeedUpEffectMonitor speedupEffectMonitor;

    #endregion

    #region Properties

    /// <summary>
    /// Get whether the speedup effect is active
    /// </summary>
    public static bool IsActive
    {

        get { return speedupEffectMonitor.IsActive; }
    }

    /// <summary>
    /// Get the speed factor for the speedup effect
    /// </summary>
    public static float SpeedFactor
    {
        get { return speedupEffectMonitor.SpeedFactor; }
    }

    /// <summary>
    /// Get the time remaining on the speedup timer
    /// </summary>
    public static float SpeedUpTimer
    {
        get { return speedupEffectMonitor.SpeedupTimer; }
    }

    #endregion

    /// <summary>
    /// Initialize the Effecs Utils
    /// </summary>
    public static void Initialize()
    {
        speedupEffectMonitor = new SpeedUpEffectMonitor();
    }
}
