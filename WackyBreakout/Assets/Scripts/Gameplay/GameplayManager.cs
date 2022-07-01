using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
	#region Unity methods

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		// add listeners to event manager
		EventManager.AddLastBallLostListener(HandleLastBallLost);
		EventManager.AddBlockDestroyedListener(HandleBlockDestroyed);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// pause game on escape key if game isn't currently paused
		if (Input.GetKeyDown(KeyCode.Escape) &&
			Time.timeScale != 0)
		{
			MenuManager.GoToMenu(MenuName.Pause);
		}
	}

	#endregion

	#region Public methods

	/// <summary>
	/// Freezes the paddle on the given side for the given duration
	/// </summary>
	/// <param name="side">side</param>
	/// <param name="duration">duration</param>
	public void Freeze(ScreenSide side, float duration)
	{

	}

	/// <summary>
	/// Speeds up all the balls in the game for the given duration
	/// </summary>
	/// <param name="duration">duration</param>
	public void Speedup(float duration)
	{

	}

	#endregion

	#region Private methods

	/// <summary>
	/// Ends the game if the last ball is lost
	/// </summary>
	void HandleLastBallLost()
	{
		EndGame();
	}

	/// <summary>
	/// Ends the game if the last block was destroyed
	/// </summary>
	void HandleBlockDestroyed()
	{
		// play collision sound 
		AudioManager.Play("BallCollision");

		// check for 1 because the last block still exists in the scene
		// when it invokes the event
		if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
		{
			EndGame();
		}
	}

	/// <summary>
	/// Ends the current game
	/// </summary>
	public void EndGame()
	{
		// instantiate prefab and set score
		GameObject gameOverMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
		GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
		GameObject hud = GameObject.FindGameObjectWithTag("HUD");
		HUD hudScript = hud.GetComponent<HUD>();
		gameOverMessageScript.SetScore(hudScript.Score);
		AudioManager.Play("GameLost");
	}

	#endregion
}
