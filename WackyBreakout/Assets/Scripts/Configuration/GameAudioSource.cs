using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
    private void Awake()
    {
        // Make sure there is only one of this object
        if (!AudioManager.Initialized)
        {
            AudioSource audioSource = 
                gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate game object
            Destroy(gameObject);
        }
    }
}
