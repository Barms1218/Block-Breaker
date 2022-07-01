using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds a level
/// </summary>
public class LevelBuilder : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;

    [SerializeField]
    GameObject prefabBonusBlock;

    [SerializeField]
    GameObject prefabPickupBlock;

    float standardBlockProbabilty = ConfigurationUtils.StandardBlockProb;

    float bonusBlockProbability = ConfigurationUtils.BonusBlockProb;

    float freezerBlockProbability = ConfigurationUtils.FreezerBlockProb;

    float speedupBlockProbability = ConfigurationUtils.SpeedupBlockProb;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        Instantiate(prefabPaddle);

        // retrieve block size
        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        // calculate blocks per row and make sure left block position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        PlaceBlock(blockWidth, blockHeight, blocksPerRow, leftBlockOffset, topRowOffset);
    }



    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    #endregion

    #region Private Methods
    void PlaceBlock(float blockWidth, float blockHeight, int blocksPerRow, float leftBlockOffset, float topRowOffset)
    {
        // add rows of blocks
        Vector2 currentLocation = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blocksPerRow; column++)
            {
                int random = Random.Range(0, 101);

                if (random <= standardBlockProbabilty)
                {
                    GameObject block = Instantiate(prefabStandardBlock, currentLocation, Quaternion.identity);
                }
                else if (random > standardBlockProbabilty &&
                    random <= standardBlockProbabilty + bonusBlockProbability)
                {
                    GameObject block = Instantiate(prefabBonusBlock, currentLocation, Quaternion.identity);
                }
                else if (random > standardBlockProbabilty + bonusBlockProbability &&
                    random <= standardBlockProbabilty + bonusBlockProbability + freezerBlockProbability)
                {
                    GameObject block = Instantiate(prefabPickupBlock, currentLocation, Quaternion.identity);
                    block.GetComponent<PickupBlock>().Effect = PickupEffect.Freezer;
                }
                else if (random > standardBlockProbabilty + bonusBlockProbability + freezerBlockProbability
                    && random <= 100)
                {
                    GameObject block = Instantiate(prefabPickupBlock, currentLocation, Quaternion.identity);
                    block.GetComponent<PickupBlock>().Effect = PickupEffect.Speedup;
                }

                currentLocation.x += blockWidth;
            }

            // move to next row
            currentLocation.x = leftBlockOffset;
            currentLocation.y += blockHeight;
        }
    }

    #endregion
}
