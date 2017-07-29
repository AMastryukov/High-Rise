using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScroll : MonoBehaviour {

  public Transform scoreKeeper;
  public Transform[] buildings = new Transform[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    float yTransform = 
      (((float)scoreKeeper.GetComponent<ScoreKeeper>().getCurrentEnergy() -
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getMinimumEnergy()) /
      ((float)scoreKeeper.GetComponent<ScoreKeeper>().getNextLevelRequirement() -
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getMinimumEnergy())) * 200.0f;

    for (int i = 0; i < 4; i++)
    {
      buildings[i].transform.position = new Vector2(0, -yTransform - 
        (200.0f * scoreKeeper.GetComponent<ScoreKeeper>().getCurrentLevel()) +
        (200.0f * i));
    }
  }
}
