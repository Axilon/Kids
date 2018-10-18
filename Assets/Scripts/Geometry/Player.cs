using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public LayerMask layer;

    public Game game;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && game.gameStarted && !game.gameFinished)
        {
            CheckClick();
        }
	}
    private void CheckClick()
    {
        RaycastHit2D clickHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, 20f,layer);
        Debug.Log("Click");
            if(clickHit)
            {
            Debug.Log("hit = " + clickHit);
            clickHit.collider.GetComponent<CellController>().CheckCellClick();
            }
        
    }
}
