using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour {
    
    public GameObject[] stars;
    public GameObject gameMenu;
    public GameObject pauseMenu;
    public GameObject restartButton;
    public GameObject nextLevelButton;
    public GameObject confirmButton;
    public Game game;

    public static GameMenuController instance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowPauseMenu(int starsNum)
    {
        if (gameMenu.activeSelf)
        {
            confirmButton.SetActive(false);
            //gameMenu.SetActive(false);
        }
        pauseMenu.SetActive(true);
        if(starsNum == 0)
        {
            nextLevelButton.SetActive(false);
        }
        else
        {
            for (int i = 0; i < starsNum; i++)
            {
                stars[i].SetActive(true);
                nextLevelButton.SetActive(true);
            }
        }
        

    }
    public void NewLevel()
    {
        PlayerPrefs.SetInt("Geometry_LastLevel", Game.instance.currentLevel + 1);
        SceneManager.LoadScene("Geometry");
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetInt("Geometry_LastLevel", Game.instance.currentLevel);
        SceneManager.LoadScene("Geometry");
    }
    public void ConfirmChoice()
    {
        if(game.PlayerChoosedSpritesList.Count == game.LevelTaskSpritesList.Count)
        {
            StartCoroutine(Game.instance.ShowResults());
        }        
    }
}
