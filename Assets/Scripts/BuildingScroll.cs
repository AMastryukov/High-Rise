using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScroll : MonoBehaviour {

  public Transform scoreKeeper;
  public Transform[] buildings = new Transform[4];

  int swaps = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    // how far the player is to powering the next floor
    float percentageComplete = 
      (((float)scoreKeeper.GetComponent<ScoreKeeper>().getCurrentEnergy() -
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getMinimumEnergy()) /
      ((float)scoreKeeper.GetComponent<ScoreKeeper>().getNextLevelRequirement() -
      (float)scoreKeeper.GetComponent<ScoreKeeper>().getMinimumEnergy()));

    Debug.Log(percentageComplete);

    // transform based on how far along into the level the player is
    float yTransform = -(percentageComplete * 200.0f + 125.0f);

    // update the color of the windows
    buildings[0].GetChild(1).GetComponent<SpriteRenderer>().color =
      new Color(1.0f, 1.0f, 1.0f);

    buildings[1].GetChild(1).GetComponent<SpriteRenderer>().color = 
      new Color(percentageComplete, percentageComplete, percentageComplete);

    for (int i = 2; i < 4; i++)
    {
      buildings[i].GetChild(1).GetComponent<SpriteRenderer>().color =
      new Color(0.0f, 0.0f, 0.0f);
    }

    // update position of every building
    for (int i = 0; i < 4; i++)
    {
      buildings[i].transform.position = new Vector2(150, yTransform - 
        (200.0f * scoreKeeper.GetComponent<ScoreKeeper>().getCurrentLevel()) +
        (200.0f * i) +
        (200.0f * swaps));

      if (buildings[i].transform.position.y <= -325)
      {
        SwapBuildings();
      }
    }
  }

  void SwapBuildings()
  {
    Transform tempBuilding = buildings[0];

    // move all the buildings down the array
    for (int i = 0; i < 3; i++)
    {
      buildings[i] = buildings[i + 1];
    }

    // put the last building at the top
    buildings[3] = tempBuilding;

    swaps++;
  }
}
