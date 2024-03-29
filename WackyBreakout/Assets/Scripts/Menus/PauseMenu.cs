﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    /// <summary>
    /// Resumes the paused game
    /// </summary>
    public void ResumeGame()
    {
        // unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
        AudioManager.Play("MenuButton");
    }

    /// <summary>
    /// Quits the paused game
    /// </summary>
    public void QuitGame()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
