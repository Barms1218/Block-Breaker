using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bonus block
/// </summary>
public class BonusBlock : Block
{
	#region Fields

	[SerializeField]
	Sprite sprite;

    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start()
	{
		base.Start();

		// Set points value
		Points = ConfigurationUtils.BonusBlockPoints;
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}
}
