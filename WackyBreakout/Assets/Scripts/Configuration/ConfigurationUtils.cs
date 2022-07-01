using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public static float BallLifeSeconds
    {
        get { return configurationData.BallLifeSeconds; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving
    /// </summary>
    public static float BallImpulseForce
    {
        get { return DifficultyUtils.BallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    public static float MinSpawnSeconds
    {
        get { return DifficultyUtils.MinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    public static float MaxSpawnSeconds
    {
        get { return DifficultyUtils.MaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    /// <summary>
    /// Gets how many points a standard block is worth
    /// </summary>
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    /// <summary>
    /// Gets how many points a bonus block is worth
    /// </summary>
    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    /// <summary>
    /// Gets how many points a pickup block is worth
    /// </summary>
    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    /// <summary>
    /// Gets the probability value of a standard block
    /// </summary>
    public static float StandardBlockProb
    {
        get { return configurationData.StandardBlockProb; }
    }

    /// <summary>
    /// Gets how many points a bonus block is worth
    /// </summary>
    public static float BonusBlockProb
    {
        get { return configurationData.BonusBlockProb; }
    }

    /// <summary>
    /// Gets how many points a bonus block is worth
    /// </summary>
    public static float FreezerBlockProb
    {
        get { return configurationData.FreezerBlockProb; }  
    }

    /// <summary>
    /// Gets how many points a bonus block is worth
    /// </summary>
    public static float SpeedupBlockProb
    {
        get { return configurationData.SpeedupBlockProb; }
    }

    /// <summary>
    /// Get the freeze duration
    /// </summary>
    public static float FreezeDuration
    {
        get { return configurationData.FreezeDuration; }
    }

    /// <summary>
    /// Get the speedup effect duration
    /// </summary>
    public static float SpeedDuration
    {
        get { return configurationData.SpeedDuration; }
    }

    /// <summary>
    /// Get the factor of the speed increase
    /// </summary>
    public static float SpeedFactor
    {
        get { return configurationData.SpeedFactor; }
    }

    #endregion

    #region Properties for DifficultyUtils use only

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in an easy game
    /// </summary>
    public static float EasyBallImpulseForce
    {
        get { return configurationData.EasyBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a medium game
    /// </summary>
    public static float MediumBallImpulseForce
    {
        get { return configurationData.MediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a hard game
    /// </summary>
    public static float HardBallImpulseForce
    {
        get { return configurationData.HardBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public static float EasyMinSpawnSeconds
    {
        get { return configurationData.EasyMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public static float MediumMinSpawnSeconds
    {
        get { return configurationData.MediumMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public static float HardMinSpawnSeconds
    {
        get { return configurationData.HardMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public static float EasyMaxSpawnSeconds
    {
        get { return configurationData.EasyMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public static float MediumMaxSpawnSeconds
    {
        get { return configurationData.MediumMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public static float HardMaxSpawnSeconds
    {
        get { return configurationData.HardMaxSpawnSeconds; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

}
