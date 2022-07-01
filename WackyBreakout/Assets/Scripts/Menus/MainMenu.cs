using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    #region Public methods

	/// <summary>
	/// Goes to the difficulty menu
	/// </summary>
	public void GoToDifficultyMenu()
    {
		MenuManager.GoToMenu(MenuName.Difficulty);

	}

	/// <summary>
	/// Shows the help menu
	/// </summary>
	public void ShowHelp()
    {
		MenuManager.GoToMenu(MenuName.Help);
		AudioManager.Play("MenuButton");
	}

	/// <summary>
	/// Exits the game
	/// </summary>
	public void ExitGame()
    {
		Application.Quit();
    }

    #endregion
}
