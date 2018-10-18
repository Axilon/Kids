using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour {

    public Color basicColor;
    public Color choosedColor;
    public Color correctColor;
    public Color wrongColor;
    
    private bool choosed;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        choosed = false;
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = basicColor;
    }

    public void CheckCellClick()
    {
        
            switch (choosed)
            {
                case (false):
                if (Game.instance.PlayerChoosedSpritesList.Count < Game.instance.LevelTaskSpritesList.Count)
                {
                    choosed = true;
                    sprite.color = choosedColor;
                    Game.instance.AddPlayerChoiceToList(GetComponent<SpriteRenderer>());
                }
                break;

                case (true):
                    choosed = false;
                    sprite.color = basicColor;

                    Game.instance.RemovePlayerChoiceFromList(GetComponent<SpriteRenderer>());
                    break;
            }
        
        
    }

    public void SetWrongColor()
    {
        sprite.color = wrongColor;
    }
    public void SetCorrectColor()
    {
        sprite.color = correctColor;
    }
}
