
// Use this for initialization
using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ModeAccess: MonoBehaviour
{

    public static int mode;
    public static   int submenufloor;
    public static bool floorcheck = false;
    public static int floor2;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log (mode);
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
                                //setVal (2);
                                //submenufloor = 2;
                                //EasyTTSUtil.SpeechFlush ("You selected the second floor");
                                //Debug.Log (floor);
                                //Application.LoadLevel("Submenu");
                                //Debug.Log (floor);
                                //EasyTTSUtil.SpeechAdd("You swiped Right");
                            }
                            else if (swipeType.x < 0.0f || Input.GetKey ("left"))
                            {
                                // MOVE LEFT
                                Debug.Log ("MoveLeft");
                                //setVal (2);
                                //submenufloor = 2;
                                //EasyTTSUtil.SpeechFlush ("You selected the second floor");
                                //Application.LoadLevel("Submenu");
                            }
                        }

                        if (swipeType.y != 0.0f)
                        {
                            if (swipeType.y > 0.0f || Input.GetKey ("up"))
                            {
                                // MOVE UP
                                Debug.Log ("MoveUp");
                                setMode (1);
                                //submenufloor = 3;
                                EasyTTSUtil.SpeechFlush ("You selected the one route mode");
                                Application.LoadLevel("Submenu");

                            }
                            else if (swipeType.y < 0.0f || Input.GetKey ("down"))
                            {
                                // MOVE DOWN
                                Debug.Log ("MoveDown");
                                setMode (2);
								Application.LoadLevel("Submenu");
                                //submenufloor = 1;
                                EasyTTSUtil.SpeechFlush ("You selected the same destination mode");
                            }
                        }

                    }

                    break;
                }
            }
        }

    }

    void Start()
    {
        EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);

        EasyTTSUtil.SpeechAdd("You're in the mode Selection Menu");
        EasyTTSUtil.SpeechAdd("Please swipe up    to select One route mode, "+
                                     "swipe down to select same destination mode.");

    }

    void OnApplicationQuit()
    {
        EasyTTSUtil.Stop();
    }

    public int setMode (int num) {
        mode = num;
        return mode;

    }

}

