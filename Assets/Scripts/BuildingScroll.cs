using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScroll : MonoBehaviour {

  public Transform scoreKeeper;
  public Transform[] buildings = new Transform[5];

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

    // transform based on how far along into the level the player is
    float yTransform = -(percentageComplete * 200.0f + 175.0f);

    // update the color of the windows
    for (int i = 0; i < 2; i++)
    {
      buildings[i].GetChild(1).GetComponent<SpriteRenderer>().color =
        new Color(1.0f, 1.0f, 1.0f);
    }

    buildings[2].GetChild(1).GetComponent<SpriteRenderer>().color = 
      new Color(percentageComplete, percentageComplete, percentageComplete);
    
    for (int i = 3; i < 5; i++)
    {
      buildings[i].GetChild(1).GetComponent<SpriteRenderer>().color =
      new Color(0.0f, 0.0f, 0.0f);
    }
    
    // update position of every building
    for (int i = 0; i < 5; i++)
    {
      // target position
      Vector3 targetPosition = new Vector3(100, yTransform -
        (200.0f * scoreKeeper.GetComponent<ScoreKeeper>().getCurrentLevel()) +
        (200.0f * i) +
        (200.0f * swaps), 0);

      // velocity vector
      Vector3 velocity = Vector3.zero;

      // SMOOTHLY update the position
      buildings[i].transform.position = Vector3.SmoothDamp(
        buildings[i].transform.position, 
        targetPosition, 
        ref velocity, 
        0.03f);
    }
  }

  public void SwapBuildings()
  {
    Transform tempBuilding = buildings[0];

    // move all the buildings down the array
    for (int i = 0; i < 4; i++)
    {
      buildings[i] = buildings[i + 1];
    }

    // put the last building at the top
    buildings[4] = tempBuilding;
    buildings[4].position = new Vector2(100, 800);

    swaps++;
  }
}
