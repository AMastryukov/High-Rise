using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

  public Text scoreText;
  public Text levelText;

  // energy-related variables
  private int energyPerPress;
  private int currentEnergy;
  private int energyDrain;

  private int currentLevel;
  private int nextLevelRequirement;
  private int minimumEnergy;

	// Use this for initialization
	void Start () {
    // default values
    currentEnergy = 0;
    energyPerPress = 8;
    energyDrain = 2;

    currentLevel = 0;
    nextLevelRequirement = 500;
    minimumEnergy = 0;

    // start energy drain
    InvokeRepeating("EnergyDrain", 0.0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update ()
  {
    scoreText.GetComponent<Text>().text = currentEnergy.ToString();
    levelText.GetComponent<Text>().text = currentLevel.ToString();

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

  //SETTERS
  public void setEnergyPerPress(int epp)
  {
    energyPerPress = epp;
  }

  public void setCurrentEnergy(int ce)
  {
    currentEnergy = ce;
  }

  // Handle spacebar presses
  public void PressSpace()
  {
    currentEnergy = currentEnergy + energyPerPress;
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
    energyDrain += currentLevel; // increase energy drain
    nextLevelRequirement += 500 * (currentLevel + 1); // increase next floor requirement
  }
}
