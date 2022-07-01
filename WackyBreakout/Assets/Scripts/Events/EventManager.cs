using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    #region Fields

    // game started support
    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<Difficulty>> gameStartedListeners =
        new List<UnityAction<Difficulty>>();

    // ball died support
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners =
        new List<UnityAction>();

    // ball lost support
    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners =
        new List<UnityAction>();

    // points added support
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners =
        new List<UnityAction<int>>();

    // last ball lost support
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners =
        new List<UnityAction>();

    // block destroyed support
    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners =
        new List<UnityAction>();

    // Freezer Effect Activated Support
    static List<PickupBlock> freezerEffectActivatedInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectActivatedListeners =
        new List<UnityAction<float>>();

    // Speedup Effect Activated Support
    static List<PickupBlock> speedupEffectActivatedInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectActivatedListeners =
        new List<UnityAction<float, float>>();

    #endregion

    #region Game started support

    /// <summary>
    /// Adds the given script as a game started invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);
        foreach (UnityAction<Difficulty> listener in gameStartedListeners)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a game started listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedListeners.Add(listener);
        foreach (DifficultyMenu invoker in gameStartedInvokers)
        {
            invoker.AddGameStartedListener(listener);
        }
    }

    #endregion

    #region Ball died support

    /// <summary>
    /// Adds the given script as a ball died invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBallDiedInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball died listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBallDiedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a ball died invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        // remove invoker from list
        ballDiedInvokers.Remove(invoker);
    }

    #endregion

    #region Ball lost support

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBallLostInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        ballLostInvokers.Add(invoker);
        foreach (UnityAction listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBallLostListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        ballLostListeners.Add(listener);
        foreach (Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBallLostInvoker(Ball invoker)
    {
        // remove invoker from list
        ballLostInvokers.Remove(invoker);
    }

    #endregion

    #region Points added support

    /// <summary>
    /// Adds the given script as a points added invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPointsAddedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a points added listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        // add listener to list and to all invokers
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a points added invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemovePointsAddedInvoker(Block invoker)
    {
        // remove invoker from list
        pointsAddedInvokers.Remove(invoker);
    }

    #endregion

    #region Last ball lost support

    /// <summary>
    /// Adds the given script as a last ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBallLostInvoker(HUD invoker)
    {
        // add invoker to list and add all listeners to invoker
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a last ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBallLostListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    #endregion

    #region Block destroyed support

    /// <summary>
    /// Adds the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a block destroyed listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveBlockDestroyedInvoker(Block invoker)
    {
        // remove invoker from list
        blockDestroyedInvokers.Remove(invoker);
    }

    #endregion

    #region Freezer Effect Activated Support

    /// <summary>
    /// Adds the given script as a game started invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezerEffectActivatedInvokers(PickupBlock invoker)
    {
        freezerEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectActivatedListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a game started listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezerEffectActivatedListeners(UnityAction<float> listener)
    {
        freezerEffectActivatedListeners.Add(listener);
        foreach (PickupBlock invoker in freezerEffectActivatedInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a freezer effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveFreezerEffectActivatedInvoker(PickupBlock invoker)
    {
        // Remove the invoker from the list of invokers
        freezerEffectActivatedInvokers.Remove(invoker);
    }

    #endregion

    #region Speedup Effect Activated


    /// <summary>
    /// Adds the given script as a game started invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectActivatedInvokers(PickupBlock invoker)
    {
        speedupEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectActivatedListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a game started listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectActivatedListeners(UnityAction<float, float> listener)
    {
        speedupEffectActivatedListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectActivatedInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Remove the given script as a speedup effect activated invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void RemoveSpeedupEffectActivatedInvoker(PickupBlock invoker)
    {
        // Remove the invoker from the list of invokers
        speedupEffectActivatedInvokers.Remove(invoker);
    }

    /// <summary>
    /// Remove the given script as a speedup effect activated listener
    /// </summary>
    public static void RemoveSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        // Remove the listener from the list of listeners
        speedupEffectActivatedListeners.Remove(listener);
    }

    #endregion
}