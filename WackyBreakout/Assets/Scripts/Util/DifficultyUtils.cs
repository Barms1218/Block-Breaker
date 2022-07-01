using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides difficulty-specific utilities
/// </summary>
public static class DifficultyUtils
{
	#region Fields

	static Difficulty difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    public static float MinSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawnSeconds;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawnSeconds;
                default:
                    return ConfigurationUtils.EasyMinSpawnSeconds;
            }
        }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    public static float MaxSpawnSeconds
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawnSeconds;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxSpawnSeconds;
                default:
                    return ConfigurationUtils.EasyMaxSpawnSeconds;
            }
        }
    }

    /// <summary>
    /// Gets the impulse force for balls
    /// </summary>
    /// <value>ball impulse force</value>
    public static float BallImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;
                default:
                    return ConfigurationUtils.EasyBallImpulseForce;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
		EventManager.AddGameStartedListener(HandleGameStartedEvent);
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Sets the difficulty and starts the game
	/// </summary>
	/// <param name="gameDifficulty">difficulty</param>
	static void HandleGameStartedEvent(Difficulty gameDifficulty)
    {
		difficulty = gameDifficulty;
		SceneManager.LoadScene("Gameplay");
        AudioManager.Play("MenuButton");
    }

	#endregion
}
