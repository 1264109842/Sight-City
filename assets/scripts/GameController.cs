using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private string infor;
	private string currTime;

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;
	TheInformationBridge inforBri;
	//List<string> newText = new List<String>();

	// Use this for initialization
	void Start () {
		infor = null;
		inforBri = new TheInformationBridge ();
		//currTime = System.DateTime.Now.ToString ();
		//Debug.Log (currTime);
	}
	
	// Update is called once per frame
	void Update () {
		currTime = System.DateTime.Now.ToString ();
		if(infor != null)
			//Debug.Log ("information :" + infor);

		// keyboard input
		if (Input.GetKey ("up"))
		{
			/*
            print (SceneManager.GetActiveScene().name);
            SceneManager.LoadScene ("FloorPick");
            */
			print(Application.loadedLevelName);

			Application.LoadLevel("GeneralTutorial");
		}
		if (Input.GetKey ("down"))
		{
			//print ("down arrow key is held down");
			//Application.LoadLevel("FloorPick");

		}

		//touch input
		if (Input.touchCount > 0)
		{
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began:
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;
					
				case TouchPhase.Canceled:
					/* The touch is being canceled */
					isSwipe = false;
					break;
					
				case TouchPhase.Ended:
					
					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;
					
					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
					{
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y))
						{
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign (direction.x);
						}
						else {
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign (direction.y);
						}
						
						if (swipeType.x != 0.0f)
						{
							if (swipeType.x > 0.0f || Input.GetKey ("right"))
							{
								// MOVE RIGHT
								Debug.Log ("MoveRight");

								Application.LoadLevel("GeneralTutorial");
							}
							else if (swipeType.x < 0.0f || Input.GetKey ("left")) {
								// MOVE LEFT
								Debug.Log("MoveLeft");
							}
						}
						
						if (swipeType.y != 0.0f)
						{
							if (swipeType.y > 0.0f || Input.GetKey ("up"))
							{
								// MOVE UP
								//Register.gameMode = 1;
								//EasyTTSUtil.SpeechFlush ("You chose learning a map");
								//Application.LoadLevel("FloorPick");
							}
							else if (swipeType.y < 0.0f || Input.GetKey ("down"))
							{
								// MOVE DOWN
								//Register.gameMode = 2;
								//EasyTTSUtil.SpeechFlush("You chose test. Choose your starting position.");
								//Application.LoadLevel("FloorPick");
							}
						}
						
					}
					
					break;
				}
			}
		}

	}

	IEnumerator WaitingTime() {
		print(Time.time);
		yield return new WaitForSeconds(8);
		print(Time.time);
	}

	public void AcceptStringInput ( string input)
	{
		infor += input;
		infor += "\n      ";
		inforBri.setAccessLog (input + "\n");

	}
	
}
