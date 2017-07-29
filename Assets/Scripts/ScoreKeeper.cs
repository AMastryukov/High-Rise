using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

  public Text scoreText;
  
  private int energyPerPress;
  private int currentEnergy;
  private int drainPerSecond;

	// Use this for initialization
	void Start () {
    // default values
    currentEnergy = 0;
    energyPerPress = 1;
    drainPerSecond = 2;

    // start energy drain
    InvokeRepeating("EnergyDrain", 0.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
  {
    scoreText.GetComponent<Text>().text = currentEnergy.ToString();
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
    currentEnergy = currentEnergy - drainPerSecond / 2;
    if (currentEnergy < 0) { currentEnergy = 0; }
  }
}
