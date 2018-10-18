using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}

    public void SetScreenOrientation(string scene)
    {
        switch (scene)
        {
            case ("MainScene"):
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
            case ("FindShadow"):
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case ("Geometry"):
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
        }
    }
    
}
