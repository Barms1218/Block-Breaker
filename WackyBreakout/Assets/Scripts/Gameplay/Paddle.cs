﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
	#region Fields

	Rigidbody2D rb2d;
	float halfColliderWidth;
	const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
	bool isFrozen = false;
	Timer freezeTimer;

	#endregion

	#region Unity methods

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		// save for efficiency
		rb2d = GetComponent<Rigidbody2D>();
		BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
		halfColliderWidth = bc2d.size.x / 2;

		// create a freeze timer
		freezeTimer = gameObject.AddComponent<Timer>();
		freezeTimer.AddTimerFinishedListener(HandleFreezeEffectFinished);

		EventManager.AddFreezerEffectActivatedListeners(Freeze);
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{

	}

	/// <summary>
	/// FixedUpdate is called 50 times per second
	/// </summary>
	void FixedUpdate()
	{
		// move for horizontal input if not frozen
		float horizontalInput = Input.GetAxis("Horizontal");
		if (!isFrozen)
        {
			if (horizontalInput != 0)
			{
				Vector2 position = rb2d.position;
				position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond *
					Time.deltaTime;
				position.x = CalculateClampedX(position.x);
				rb2d.MovePosition(position);
			}
		}

	}

	/// <summary>
	/// Detects collision with a ball to aim the ball
	/// </summary>
	/// <param name="coll">collision info</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Ball") &&
			TopCollision(coll))
		{
			// calculate new ball direction
			float ballOffsetFromPaddleCenter = transform.position.x -
				coll.transform.position.x;
			float normalizedBallOffset = ballOffsetFromPaddleCenter /
				halfColliderWidth;
			float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
			float angle = Mathf.PI / 2 + angleOffset;
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

			// tell ball to set direction to new direction
			Ball ballScript = coll.gameObject.GetComponent<Ball>();
			ballScript.SetDirection(direction);

			// play collision sound 
			AudioManager.Play("BallCollision");
		}
	}

	#endregion

	#region Public methods

	/// <summary>
	/// Freezes the paddle for the given duration
	/// </summary>
	/// <param name="duration">duration</param>
	public void Freeze(float duration)
    {
		isFrozen = true;
		freezeTimer.Duration = duration;

		if (!freezeTimer.Running)
		{
			freezeTimer.Run();
		}
		else
		{
			freezeTimer.AddTime(duration);
		}
		AudioManager.Play("Freeze");
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Calculates an x position to clamp the paddle in the screen
	/// </summary>
	/// <param name="x">the x position to clamp</param>
	/// <returns>the clamped x position</returns>
	float CalculateClampedX(float x)
	{
		// clamp left and right edges
		if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
		{
			x = ScreenUtils.ScreenLeft + halfColliderWidth;
		}
		else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
		{
			x = ScreenUtils.ScreenRight - halfColliderWidth;
		}
		return x;
	}

	/// <summary>
	/// Checks for a collision on the top of the paddle
	/// </summary>
	/// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
	/// <param name="coll">collision info</param>
	bool TopCollision(Collision2D coll)
	{
		const float tolerance = 0.05f;

		// on top collisions, both contact points are at the same y location
		ContactPoint2D[] contacts = coll.contacts;
		return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
	}

	/// <summary>
	/// Stop the timer and unfreeze the paddle
	/// </summary>
	void HandleFreezeEffectFinished()
    {
		freezeTimer.Stop();
		isFrozen = false;
    }

	#endregion
}
