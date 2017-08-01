using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTracker : MonoBehaviour {

  public Text autoClickerCountText;
  public Text buyBoostText;
  public Text boostDescriptionText;
  public Text buyClickerText;
  public Text clickerDescriptionText;
  public Text clickerBoostText;
  public Text clickerBoostDescriptionText;

  public Transform scoreKeeper;

  public Transform workerButton;
  public Transform boostButton;
  public Transform workerBoostButton;

  private int autoClickerCount = 0;
  private int boostCount = 0;

  private int autoClickerCost = 10;
  private int boostCost = 20;

  private int workerBoostCount = 0;
  private int workerBoostCost = 50;

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
    autoClickerCountText.GetComponent<Text>().text = "Pressers: " + autoClickerCount.ToString();
    buyBoostText.GetComponent<Text>().text = "BUY BOOST [$" + boostCost.ToString() + "]";
    buyClickerText.GetComponent<Text>().text = "BUY PRESSER [$" + autoClickerCost.ToString() + "]";
    clickerBoostText.GetComponent<Text>().text = "BUY PRESSER BOOST [$" + workerBoostCost.ToString() + "]";

    // handle clicker purchase buttons enabling/disabling
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= autoClickerCost)
    {
      workerButton.GetComponent<Button>().interactable = true;
    } else
    {
      workerButton.GetComponent<Button>().interactable = false;
    }

    // handle boost purchase buttons enabling/disabling
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= boostCost)
    {
      boostButton.GetComponent<Button>().interactable = true;
    }
    else
    {
      boostButton.GetComponent<Button>().interactable = false;
    }

    // handle clicker boost purchase buttons enabling/disabling
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= workerBoostCost)
    {
      workerBoostButton.GetComponent<Button>().interactable = true;
    }
    else
    {
      workerBoostButton.GetComponent<Button>().interactable = false;
    }
  }

  public void PurchaseAutoClicker()
  {
    // if the player can afford the powerup, update values
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= autoClickerCost)
    {
      autoClickerCount++;
      scoreKeeper.GetComponent<ScoreKeeper>().setPoints(scoreKeeper.GetComponent<ScoreKeeper>().getPoints() - autoClickerCost);
      autoClickerCost += 5 + autoClickerCount;

      // invoke a repeating autoclicker
      InvokeRepeating("AutoClick", 0.0f, 0.5f);
    }
  }

  public void PurchaseBoost()
  {
    // if the player can afford the powerup, update values
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= boostCost)
    {
      boostCount++;
      scoreKeeper.GetComponent<ScoreKeeper>().setEnergyPerPress(scoreKeeper.GetComponent<ScoreKeeper>().getEnergyPerPress() + 1);
      scoreKeeper.GetComponent<ScoreKeeper>().setPoints(scoreKeeper.GetComponent<ScoreKeeper>().getPoints() - boostCost);
      boostCost += 6 + boostCount;
    }
  }

  public void PurchaseWorkerBoost()
  {
    // if the player can afford the powerup, update values
    if (scoreKeeper.GetComponent<ScoreKeeper>().getPoints() >= workerBoostCost)
    {
      workerBoostCost++;
      scoreKeeper.GetComponent<ScoreKeeper>().increaseWorkerEnergyPerPress();
      workerBoostCost += 10 * boostCount;
    }
  }

  public void AutoClick()
  {
    scoreKeeper.GetComponent<ScoreKeeper>().WorkerPressSpace();
  }
}
