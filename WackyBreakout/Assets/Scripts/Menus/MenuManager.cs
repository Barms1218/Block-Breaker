using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The menu manager
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="menu">menu to go to</param>
    public static void GoToMenu(MenuName menu)
    {
        switch (menu)
        {
            case MenuName.Difficulty:

                // go to Difficulty Menu scene
                SceneManager.LoadScene("DifficultyMenu");
                AudioManager.Play("MenuButton");
                break;
            case MenuName.Help:

                // go to Help Menu scene
                SceneManager.LoadScene("HelpMenu");
                AudioManager.Play("MenuButton");
                break;
            case MenuName.Main:

                // go to Main Menu scene
                SceneManager.LoadScene("MainMenu");
                AudioManager.Play("MenuButton");
                break;
            case MenuName.Pause:

                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
}
