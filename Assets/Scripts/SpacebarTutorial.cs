using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpacebarTutorial : MonoBehaviour {

  int tutorialProgress = 0;
  public Text spacebarText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      tutorialProgress++;
      UpdateTutorialText();
    }
  }

  // update tutorial text
  void UpdateTutorialText()
  {
    switch(tutorialProgress)
    {
      case 1:
        spacebarText.GetComponent<Text>().text = "PRESS SPACEBAR AGAIN";
        break;
      case 2:
        spacebarText.GetComponent<Text>().text = "AND AGAIN!";
        break;
      case 3:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 4:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 5:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 6:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 7:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 8:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 9:
        Destroy(gameObject);
        break;
    }
  }
}
