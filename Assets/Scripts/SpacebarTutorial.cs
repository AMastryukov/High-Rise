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

      gameObject.transform.localScale = new Vector3(2.35f, 2.35f, 2.35f);
      gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f);
    }

    if (Input.GetKeyUp(KeyCode.Space))
    {
      gameObject.transform.localScale = new Vector3(2.4f, 2.4f, 2.4f);
      gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
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
      case 6:
        spacebarText.GetComponent<Text>().text = "KEEP GOING!";
        break;
      case 15:
        Destroy(gameObject);
        break;
    }
  }
}
