using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int currentLevel = 0;
    public bool gameStarted;
    public bool gameFinished;
    public GameObject taskShowerGO;
    public GameObject grid;
    public GameObject popUpMwssage;
    public GameController gameController;
    public Text currentLevelText;

    private int lastComplitedLevel;
    private float showTime = 3f;
    private List<Sprite> levelTaskSpritesList = new List<Sprite>();
    private List<SpriteRenderer> playerChoosedSpritesList = new List<SpriteRenderer>();
    private GameMenuController gameMenuController;

    public static Game instance;

    public List<Sprite> LevelTaskSpritesList
    {
        get
        {
            return levelTaskSpritesList;
        }
    }
    public List<SpriteRenderer> PlayerChoosedSpritesList
    {
        get
        {
            return playerChoosedSpritesList;
        }
    }
    // Use this for initialization
    void Start()
    {
        InitializeGame();
    }

    public void AddPlayerChoiceToList(SpriteRenderer sprite)
    {
        playerChoosedSpritesList.Add(sprite);
    }
    public void RemovePlayerChoiceFromList(SpriteRenderer sprite)
    {
        playerChoosedSpritesList.Remove(sprite);
    }

    private void InitializeGame()
    {
        gameMenuController = GameObject.Find("UI").GetComponent<GameMenuController>();
        currentLevel = lastComplitedLevel = PlayerPrefs.GetInt("Geometry_LastLevel", 1);
        currentLevelText.text = "Level " + currentLevel.ToString();

        if (instance == null)
        {
            instance = this;
        }
        levelTaskSpritesList = gameController.CreateSpritesList(currentLevel);
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        popUpMwssage.SetActive(true);
        yield return new WaitForSeconds(5f);
        popUpMwssage.SetActive(false);
        yield return new WaitForSeconds(2f);
        foreach (Sprite sp in levelTaskSpritesList)
        {
            taskShowerGO.GetComponent<SpriteRenderer>().sprite = sp;
            taskShowerGO.SetActive(true);
            yield return new WaitForSeconds(SetShowTime());
            taskShowerGO.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        grid.SetActive(true);
        gameStarted = true;
        gameFinished = false;
        gameMenuController.confirmButton.SetActive(true);
    }
    private float SetShowTime()
    {
        if (currentLevel > 3)
        {
            float timeDicrement = (currentLevel - 3) * 0.1f;
            if ( timeDicrement< 1.5f)
            {
                return showTime - timeDicrement;
            }
            else
            {
                return showTime - 1.5f;
            }
        }
        return showTime;
    }
    public IEnumerator ShowResults()
    {
        gameFinished = true;
        yield return new WaitForSeconds(1f);
        int starsToShow = CheckChoice();
        yield return new WaitForSeconds(2f);
        gameMenuController.ShowPauseMenu(starsToShow);
    }

    private int CheckChoice()
    {
        int stars = 0;
        if (ThreeStarsCheck())
        {
            return stars=3;
        }
        int score = StarsCheck();

         if (levelTaskSpritesList.Count == score)
        {
            stars=2;
        }else if(score >= 1)
        {
            stars=1;
        }
        return stars;
       
    }

    private bool ThreeStarsCheck()
    {
        int similar = 0;
        for (int i = 0; i < levelTaskSpritesList.Count; i++)
        {
            if (levelTaskSpritesList[i] != playerChoosedSpritesList[i].sprite)
            {
                break;
            }
            else
            {
                playerChoosedSpritesList[i].GetComponent<CellController>().SetCorrectColor();
            }
            similar++;
        }
        if (similar == levelTaskSpritesList.Count)
        {
            return true;
        }
        return false;
    }
    private int StarsCheck()
    {
        int similar = 0;
        for(int i = 0; i < playerChoosedSpritesList.Count; i++)
        {
              foreach(Sprite sp in levelTaskSpritesList)
            {
                if (playerChoosedSpritesList[i].sprite == sp)
                {
                    playerChoosedSpritesList[i].GetComponent<CellController>().SetCorrectColor();
                    similar++;
                    break;
                }
                else
                {
                    playerChoosedSpritesList[i].GetComponent<CellController>().SetWrongColor();
                }
            }
        }

       return similar;

    }
}
