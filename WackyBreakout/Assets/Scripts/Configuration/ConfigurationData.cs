using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10f;
    float ballLifeSeconds = 10f;
    float easyBallImpulseForce = 200f;
    float easyMinSpawnSeconds = 5f;
    float easyMaxSpawnSeconds = 10f;
    float mediumBallImpulseForce = 300f;
    float mediumMinSpawnSeconds = 3f;
    float mediumMaxSpawnSeconds = 7f;
    float hardBallImpulseForce = 400f;
    float hardMinSpawnSeconds = 2f;
    float hardMaxSpawnSeconds = 5f;
    int ballsPerGame = 5;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int pickupBlockPoints = 5;
    float standardBlockProb = 70f;
    float bonusBlockProb = 20f;
    float freezerBlockProb = 5f;
    float speedupBlockProb = 5f;
    float freezeDuration = 2f;
    float speedDuration = 2f;
    float speedFactor = 2f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in an easy game
    /// </summary>
    public float EasyBallImpulseForce
    {
        get { return easyBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a medium game
    /// </summary>
    public float MediumBallImpulseForce
    {
        get { return mediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a hard game
    /// </summary>
    public float HardBallImpulseForce
    {
        get { return hardBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public float EasyMinSpawnSeconds
    {
        get { return easyMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public float MediumMinSpawnSeconds
    {
        get { return mediumMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public float HardMinSpawnSeconds
    {
        get { return hardMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public float EasyMaxSpawnSeconds
    {
        get { return easyMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public float MediumMaxSpawnSeconds
    {
        get { return mediumMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public float HardMaxSpawnSeconds
    {
        get { return hardMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    /// <summary>
    /// Gets how many points a standard block is worth
    /// </summary>
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// Get how many points a bonus block is worth
    /// </summary>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints;}
    }

    /// <summary>
    /// Get how many points a pickup block is worth
    /// </summary>
    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    /// <summary>
    /// Get the probability value of a standard block
    /// </summary>
    public float StandardBlockProb
    {
        get { return standardBlockProb; }
    }

    /// <summary>
    /// Get the probability value of a bonus block
    /// </summary>
    public float BonusBlockProb
    {
        get { return bonusBlockProb;}
    }

    /// <summary>
    /// Get the probability value of a freezer block
    /// </summary>
    public float FreezerBlockProb
    {
        get { return freezerBlockProb; }
    }

    /// <summary>
    /// Get the probability value of a speedup block block
    /// </summary>
    public float SpeedupBlockProb
    {
        get { return speedupBlockProb; }
    }

    /// <summary> 
    /// Get the duration of the freeze effect
    /// </summary>
    public float FreezeDuration
    {
        get { return freezeDuration; }
    }

    /// <summary>
    /// Get the duration of the speedup effect
    /// </summary>
    public float SpeedDuration
    {
        get { return speedDuration; }
    }

    /// <summary>
    /// Get the factor of the speed increase
    /// </summary>
    public float SpeedFactor
    {
        get { return speedFactor; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballLifeSeconds = float.Parse(values[1]);
        easyBallImpulseForce = float.Parse(values[2]);
        easyMinSpawnSeconds = float.Parse(values[3]);
        easyMaxSpawnSeconds = float.Parse(values[4]);
        mediumBallImpulseForce = float.Parse(values[5]);
        mediumMinSpawnSeconds = float.Parse(values[6]);
        mediumMaxSpawnSeconds = float.Parse(values[7]);
        hardBallImpulseForce = float.Parse(values[8]);
        hardMinSpawnSeconds = float.Parse(values[9]);
        hardMaxSpawnSeconds = float.Parse(values[10]);
        ballsPerGame = int.Parse(values[11]);
        standardBlockPoints = int.Parse(values[12]);
        bonusBlockPoints = int.Parse(values[13]);
        pickupBlockPoints = int.Parse(values[14]);
        standardBlockProb = float.Parse(values[15]);
        bonusBlockProb = float.Parse(values[16]);
        freezerBlockProb = float.Parse(values[17]);
        speedupBlockProb = float.Parse(values[18]);
        freezeDuration = float.Parse(values[19]);
        speedDuration = float.Parse(values[20]);
        speedFactor = float.Parse(values[21]);
    }
}
