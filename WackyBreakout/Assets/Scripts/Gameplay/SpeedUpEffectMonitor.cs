using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedUpEffectMonitor : MonoBehaviour
{
    #region Fields

    Timer speedupTimer;

    bool isActive;

    float speedFactor;

    #endregion

    #region Properties

    /// <summary>
    /// Get whether the effect is active
    /// </summary>
    public bool IsActive
    {
        get 
        { 
            return isActive; 
        }
    }

    /// <summary>
    /// Get the speed factor of the speedup effect
    /// </summary>
    public float SpeedFactor
    {
        get 
        { 
            return speedFactor; 
        }
    }

    /// <summary>
    /// Get the remaining duration of the timer
    /// </summary>
    public float SpeedupTimer
    {
        get 
        { 
            return speedupTimer.RemainingTime; 
        } 
    }

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(SpeedUpEffectFinished);

        EventManager.AddSpeedupEffectActivatedListeners(SpeedUpEffectListener);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Private Methods

    // Assign values to fields exposed in properties
    void SpeedUpEffectListener(float speedupFactor, float duration)
    {
        speedupTimer.Duration = duration;
        speedFactor = speedupFactor;
        isActive = true;

        if (!speedupTimer.Running)
        {
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    /// <summary>
    /// Sto the timer and set the boolean to false
    /// </summary>
    void SpeedUpEffectFinished()
    {
        speedupTimer.Stop();
        isActive = false;
    }

    #endregion
}
