using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;
    private bool once;
	//Register reg;

	void Awake()
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);
		once = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(!once)
        {
            introMessage();
            once = true;
        }
        
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
								Register.gameMode = 1;
                                EasyTTSUtil.SpeechFlush ("You chose learning a map");
                                Application.LoadLevel("FloorPick");
                            }
                            else if (swipeType.y < 0.0f || Input.GetKey ("down"))
                            {
                                // MOVE DOWN
								Register.gameMode = 2;
                                EasyTTSUtil.SpeechFlush("You chose test. Choose your starting position.");
                                Application.LoadLevel("FloorPick");
                            }
                        }

                    }

                    break;
                }
            }
        }

    }

    void OnApplicationQuit()
    {
        EasyTTSUtil.Stop();
    }

    void introMessage()
    {
        EasyTTSUtil.SpeechFlush("Welcome to the Sight City Game!");
        EasyTTSUtil.SpeechAdd("Please Swipe Up for a learning a map or Swipe Down to test your learning " +
                              "through the layer");
    }

}
