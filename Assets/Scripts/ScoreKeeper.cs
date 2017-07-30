using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

  public Text energyText;
  public Text levelText;
  public Text scoreText;
  public Text pressRateText;

  public Transform powerupTracker;
  public Transform buildingScroll;

  // energy-related variables
  private int energyPerPress;
  private int currentEnergy;
  private int energyDrain;

  private int currentLevel;
  private int nextLevelRequirement;
  private int minimumEnergy;

  private int points;

	// Use this for initialization
	void Start () {
    // default values
    currentEnergy = 0;
    energyPerPress = 5;
    energyDrain = 0;

    currentLevel = 0;
    nextLevelRequirement = 20;
    minimumEnergy = 0;

    points = 0;

    // start energy drain
    InvokeRepeating("EnergyDrain", 0.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update ()
  {
    energyText.GetComponent<Text>().text = (currentEnergy - minimumEnergy).ToString() + "/" + (nextLevelRequirement - minimumEnergy).ToString();
    levelText.GetComponent<Text>().text = currentLevel.ToString();
    scoreText.GetComponent<Text>().text = points.ToString();
    pressRateText.GetComponent<Text>().text = "Power/press:\n" + energyPerPress.ToString();

    // if the next energy level is reached, increase level
    if (currentEnergy >= nextLevelRequirement)
    {
      NextLevel();
    }
	}

  // GETTERS
  public int getEnergyPerPress()
  {
    return energyPerPress;
  }

  public int getCurrentEnergy()
  {
    return currentEnergy;
  }

  public int getMinimumEnergy()
  {
    return minimumEnergy;
  }

  public int getNextLevelRequirement()
  {
    return nextLevelRequirement;
  }

  public int getCurrentLevel()
  {
    return currentLevel;
  }

  public int getPoints()
  {
    return points;
  }

  //SETTERS
  public void setEnergyPerPress(int epp)
  {
    energyPerPress = epp;
  }

  public void setCurrentEnergy(int ce)
  {
    currentEnergy = ce;
  }

  public void setPoints(int p)
  {
    points = p;
  }

  // Handle spacebar presses
  public void PressSpace()
  {
    currentEnergy = currentEnergy + energyPerPress;
    points++;
  }

  // Handle energy drain
  public void EnergyDrain()
  {
    currentEnergy = currentEnergy - energyDrain;
    if (currentEnergy < minimumEnergy) { currentEnergy = minimumEnergy; }
  }

  // increase energy level requirements for next level
  private void NextLevel()
  {
    currentLevel++; // increase level

    minimumEnergy = nextLevelRequirement; // increase minimum energy level

    if (currentLevel % 2 == 0)
    {
      energyDrain++; // increase energy drain
    }
    nextLevelRequirement += 10 * (currentLevel + 1); // increase next floor requirement

    // update the building scroll
    buildingScroll.GetComponent<BuildingScroll>().SwapBuildings();
  }
}
