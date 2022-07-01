using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    #region Fields

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<string, AudioClip> audioClips =
        new Dictionary<string, AudioClip>();

    #endregion

    #region Properties

    /// <summary>
    /// Get whether or not he audio manager is initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source>audio source</
    /// param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        // Dictionary loaded with clips from Resources
        audioClips.Add("BallCollision", 
            Resources.Load<AudioClip>("BallCollision"));
        audioClips.Add("BallLost",
            Resources.Load<AudioClip>("BallLost"));
        audioClips.Add("BallSpawn",
            Resources.Load<AudioClip>("BallSpawn"));
        audioClips.Add("Freeze",
            Resources.Load<AudioClip>("Freeze"));
        audioClips.Add("GameLost",
            Resources.Load<AudioClip>("GameLost"));
        audioClips.Add("MenuButton",
            Resources.Load<AudioClip>("MenuButton"));
        audioClips.Add("Speedup",
            Resources.Load<AudioClip>("Speedup"));

    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="=name">name of the audio
    /// clip to play</param>
    public static void Play(string name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}
