using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<Sprite> listOfSprite;

    private int maxSpritesForLevel;
    private const int minNumberOfSpritesForLevel = 3;

    public static GameController instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public List<Sprite> CreateSpritesList(int levelNumber)
    {
        maxSpritesForLevel = minNumberOfSpritesForLevel;
        List<Sprite> returnList = new List<Sprite>();
        if (levelNumber > 3)
        {
            maxSpritesForLevel = minNumberOfSpritesForLevel + (levelNumber/3);
            if (maxSpritesForLevel >= listOfSprite.Count)
            {
                maxSpritesForLevel = listOfSprite.Count - 2;
            }
        }
        for(int i = 0; i < maxSpritesForLevel; i++)
        {
            int randomNum = Random.Range(0, listOfSprite.Count-1);
            for (; returnList.Contains(listOfSprite[randomNum]);)
            {
                randomNum = Random.Range(0, listOfSprite.Count - 1);
            }
            returnList.Add(listOfSprite[randomNum]);
        }

        return returnList;
    }
}
