using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarPress : MonoBehaviour {

  public ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
    {
      scoreKeeper.GetComponent<ScoreKeeper>().PressSpace();
    }
	}
}
