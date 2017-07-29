using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScroll : MonoBehaviour {

  public Transform scoreKeeper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    float yTransform = 
      (((float)scoreKeeper.GetComponent<ScoreKeeper>().getCurrentEnergy() -
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getMinimumEnergy()) /
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getNextLevelRequirement()) * 200.0f;

    transform.position = new Vector2(0, -yTransform);
	}
}
