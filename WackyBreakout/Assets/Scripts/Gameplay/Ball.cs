using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields

    // save for efficiency
    Rigidbody2D rb2d;

    // move delay timer
    Timer moveTimer;

    // death support
    Timer deathTimer;
    BallDiedEvent ballDiedEvent = new BallDiedEvent();

    // loss support
    BallLostEvent ballLostEvent = new BallLostEvent();

    // speedup support
    Timer speedupTimer;
    float speedFactor;
    [SerializeField]
    bool isActive;

    #endregion

    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // save for efficiency
        rb2d = GetComponent<Rigidbody2D>();

        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
        moveTimer.AddTimerFinishedListener(HandleMoveTimerFinished);

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);

        // add as invoker of events
        EventManager.AddBallDiedInvoker(this);
        EventManager.AddBallLostInvoker(this);

        // add as listener of events
        EventManager.AddSpeedupEffectActivatedListeners(Speedup);


        // create speedup Timer
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupFinished);
    }

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // invoke event and destroy self
            ballLostEvent.Invoke();
            AudioManager.Play("BallLost");
            DestroyBall();
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// Speeds up the ball by the given speedup factor
    /// for the given duration
    /// </summary>
    /// <param name="speedupFactor">speedup factor</param>
    /// <param name="duration">duration</param>
    public void Speedup(float speedupFactor, float duration)
    {
        speedFactor = speedupFactor;
        speedupTimer.Duration = duration;

        if (!speedupTimer.Running)
        {
            speedupTimer.Run();
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    /// <summary>
    /// Adds the given listener for the BallDiedEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the BallLostEvent
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddBallLostListener(UnityAction listener)
    {
        ballLostEvent.AddListener(listener);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        isActive = EffectsUtils.IsActive;

        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

        if (isActive)
        {
            force *= EffectsUtils.SpeedFactor;
        }
        rb2d.AddForce(force);
    }

    /// <summary>
    /// Destroys the ball
    /// </summary>
    void DestroyBall()
    {
        EventManager.RemoveSpeedupEffectActivatedListener(Speedup);
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        Destroy(gameObject);
    }

    /// <summary>
    /// Stops the move timer and starts the ball moving
    /// </summary>
    void HandleMoveTimerFinished()
    {
        moveTimer.Stop();
        StartMoving();
    }

    /// <summary>
    /// Invokes event and destroys ball
    /// </summary>
    void HandleDeathTimerFinished()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }

    /// <summary>
    /// Invokes the event and slows the balls
    /// </summary>
    void HandleSpeedupFinished()
    {
        speedupTimer.Stop();
        rb2d.velocity *= 1 / speedFactor;
    }

    #endregion
}
