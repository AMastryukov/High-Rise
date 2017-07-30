using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTracker : MonoBehaviour {

  public Text autoClickerCountText;
  public Text buyBoostText;
  public Text buyClickerText;

  public Transform scoreKeeper;

  private int autoClickerCount = 0;
  private int boostCount = 0;

  private int autoClickerCost = 10;
  private int boostCost = 25;

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
    autoClickerCountText.GetComponent<Text>().text = "Workers:\n" + autoClickerCount.ToString();
    buyBoostText.GetComponent<Text>().text = "Buy Boost [" + boostCost.ToString() + "]";
    buyClickerText.GetComponent<Text>().text = "Hire Worker [" + autoClickerCost.ToString() + "]";
  }

  public void PurchaseAutoClicker()
  {
    // if the player can afford the powerup, update values
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= autoClickerCost)
    {
      autoClickerCount++;
      scoreKeeper.GetComponent<ScoreKeeper>().setPoints(scoreKeeper.GetComponent<ScoreKeeper>().getPoints() - autoClickerCost);
      autoClickerCost += autoClickerCost;

      // invoke a repeating autoclicker
      InvokeRepeating("AutoClick", 0.0f, 1.0f);
    }
  }

  public void PurchaseBoost()
  {
    // if the player can afford the powerup, update values
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= boostCost)
    {
      boostCount++;
      scoreKeeper.GetComponent<ScoreKeeper>().setEnergyPerPress(scoreKeeper.GetComponent<ScoreKeeper>().getEnergyPerPress() + 1 * boostCount);
      scoreKeeper.GetComponent<ScoreKeeper>().setPoints(scoreKeeper.GetComponent<ScoreKeeper>().getPoints() - boostCost);
      boostCost += boostCost;
    }
  }

  public void AutoClick()
  {
    scoreKeeper.GetComponent<ScoreKeeper>().PressSpace();
  }
}
