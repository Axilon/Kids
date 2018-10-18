using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
    public List<Sprite> matList = new List<Sprite>();
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = matList[Random.Range(0, matList.Count - 1)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
