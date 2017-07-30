using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorWindows : MonoBehaviour {

  public Transform indoorSprite;
  public Sprite[] windowSprites = new Sprite[8];

	// Use this for initialization
	void Start () {
    randomizeWindowSprite();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void randomizeWindowSprite()
  {
    indoorSprite.GetComponent<SpriteRenderer>().sprite = windowSprites[Random.Range(0,8)];
  }
}
