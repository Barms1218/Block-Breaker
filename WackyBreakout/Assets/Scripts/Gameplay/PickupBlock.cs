using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A pickup block for the freezer or speedup effect
/// </summary>
public class PickupBlock : Block
{
    #region Fields

    PickupEffect effect;
    float duration;
	float speedupFactor;

	[SerializeField]
	Sprite freezerBlockSprite;

	[SerializeField]
	Sprite speedupBlockSprite;

	FreezerEffectActivatedEvent freezerEffectActivatedEvent;

	SpeedupEffectActivatedEvent speedupEffectActivatedEvent;

    #endregion

    #region Properties

    public PickupEffect Effect
    {
		set 
		{
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			effect = value;
			if (effect == PickupEffect.Freezer)
            {
				duration = ConfigurationUtils.FreezeDuration;
				freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
				EventManager.AddFreezerEffectActivatedInvokers(this);
				spriteRenderer.sprite = freezerBlockSprite;
			}
			else if (effect == PickupEffect.Speedup)
            {
				duration = ConfigurationUtils.SpeedDuration;
				speedupFactor = ConfigurationUtils.SpeedFactor;
				speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
				EventManager.AddSpeedupEffectActivatedInvokers(this);
				spriteRenderer.sprite = speedupBlockSprite;
            }


		}
    }

    #endregion

    #region Unity Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start()
	{
		base.Start();


		// Set the point value of the pickup blocks
		Points = ConfigurationUtils.PickupBlockPoints;
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

	// Invoke the correct event based on the type of block hit
	override protected void OnCollisionEnter2D(Collision2D coll)
    {
		base.OnCollisionEnter2D(coll);
		if (effect == PickupEffect.Freezer)
        {
			freezerEffectActivatedEvent.Invoke(duration);
			EventManager.RemoveFreezerEffectActivatedInvoker(this);
		}
		else
        {
			speedupEffectActivatedEvent.Invoke(speedupFactor, duration);
			EventManager.RemoveSpeedupEffectActivatedInvoker(this);
        }

    }
	#endregion


	#region Public Methods

	// Add the given listener as a listener for the event
	public void AddFreezerEffectListener(UnityAction<float> listener)
    {
		freezerEffectActivatedEvent.AddListener(listener);
    }

	// Add the given listener as a listener for the event
	public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
		speedupEffectActivatedEvent.AddListener(listener);
    }

	// Remove the given listener as a listener for the event
	public void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
		EventManager.RemoveSpeedupEffectActivatedListener(listener);
    }

	#endregion
}
