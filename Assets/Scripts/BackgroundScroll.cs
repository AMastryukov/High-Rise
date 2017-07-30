using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

  public Transform[] skyVariants = new Transform[3];
  public Transform skyline;
  public ScoreKeeper scoreKeeper;

  private int swaps = 0;

  Vector3 startingPosition;

  // Use this for initialization
  void Start () {
    startingPosition = skyline.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    // update the sky positions
		for (int i = 0; i < 3; i++)
    {
      // target position
      Vector3 targetPosition = new Vector3(
        startingPosition.x,
        startingPosition.y + 
        300 * (swaps) +
        300 * (i + 1) -
        scoreKeeper.GetComponent<ScoreKeeper>().getCurrentLevel() * 5,
        startingPosition.z);

      // velocity vector
      Vector3 velocity = Vector3.zero;

      // SMOOTHLY update the position
      skyVariants[i].transform.position = Vector3.SmoothDamp(
        skyVariants[i].transform.position,
        targetPosition,
        ref velocity,
        0.2f);
    }

    // move the skyline down as well
    if (skyline.transform.position.y > -300)
    {
      // target position
      Vector3 targetPosition = new Vector3(
        startingPosition.x,
        startingPosition.y -
        scoreKeeper.GetComponent<ScoreKeeper>().getCurrentLevel() * 5,
        startingPosition.z);

      // velocity vector
      Vector3 velocity = Vector3.zero;

      // SMOOTHLY update the position
      skyline.transform.position = Vector3.SmoothDamp(
        skyline.transform.position,
        targetPosition,
        ref velocity,
        0.2f);
    }

    // shift the bottom sky to the top
    if (skyVariants[0].position.y <= -300)
    {
      SwapSky();
    }
  }

  public void SwapSky()
  {
    Transform tempSky = skyVariants[0];

    // move the skies down the array
    for (int i = 0; i < 2; i++)
    {
      skyVariants[i] = skyVariants[i + 1];
    }

    // put the last sky at the top
    skyVariants[2] = tempSky;
    skyVariants[2].position = new Vector2(
      startingPosition.x,
      startingPosition.y + 600);

    swaps++;
  }
}
