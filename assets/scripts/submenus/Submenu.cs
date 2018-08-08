using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Submenu : ModeAccess
{
	//RoomLocationsConf rlc ;
	//public static bool select = true;
	//public static int redund = 0;
	/*public static string x;
	public static string y;
	public Text room_text;
	public string choice="";*/
	//public string[] rooms=new string[15];
	//   public GameObject droom;
	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	public static Vector3 startP;
	public static Vector3 endP;
	
	//private DynamicRooms dr = new DynamicRooms();
	void Start()
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);
		//Debug.Log (floorPick());
		introToCurrentMenu();
		//rlc = new RoomLocationsConf ();
	}
	
	void Update() 
	{
		
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
						
						if (swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f || Input.GetKey ("right")) {
								// MOVE RIGHT
								Debug.Log ("MoveRight");
								EasyTTSUtil.SpeechFlush ("You chose a harder route");
								if(Register.gameMode == 1)
								{
									Register.startPoint = new Vector3(80f,2f,-53.6f);
									Register.endPoint = new Vector3(-23f,2f,173f);
									Application.LoadLevel("CCNYGrove");
								}else{
									Register.startPoint = new Vector3(80f,2f,-53.6f);
									Register.endPoint = new Vector3(-23f,2f,173f);
									Application.LoadLevel("CCNYGroveTest");
								}

							} else if (swipeType.x < 0.0f || Input.GetKey ("left")) {
								// MOVE LEFT
								Debug.Log ("MoveLeft");
								EasyTTSUtil.SpeechFlush ("You chose a harder route");
								if(Register.gameMode == 1 )
								{
									Register.startPoint = new Vector3(80f,2f,-53.6f);
									Register.endPoint = new Vector3(-23f,2f,173f);
									Application.LoadLevel("CCNYGrove");
								}else { 									// game mode == 2 && mode == 1
									Register.startPoint = new Vector3(80f,2f,-53.6f);
									Register.endPoint = new Vector3(-23f,2f,173f);
									Application.LoadLevel("CCNYGroveTest");
								}
							}
						}
						
						if (swipeType.y != 0.0f) {
							if (swipeType.y > 0.0f || Input.GetKey ("up")) {
								// MOVE UP
								EasyTTSUtil.SpeechFlush ("You chose a simple route");
								if(Register.gameMode == 1)
								{
									startP = new Vector3(104f,2f,-103f);
									endP = new Vector3(-51f,2f,-88f);
									Application.LoadLevel("CCNYGrove");
								}else{
									startP = new Vector3(104f,2f,-103f);
									endP = new Vector3(-51f,2f,-88f);
									Application.LoadLevel("CCNYGroveTest");
								}
							} else if (swipeType.y < 0.0f || Input.GetKey ("down")) {
								// MOVE DOWN
								EasyTTSUtil.SpeechFlush ("You chose a normal route");
								if(Register.gameMode == 1)
								{
									startP = new Vector3(161f,2f,-140f);
									endP = new Vector3(18f,2f,-7f);
									Application.LoadLevel("CCNYGrove");
								}else{
									startP = new Vector3(161f,2f,-140f);
									endP = new Vector3(18f,2f,-7f);
									Application.LoadLevel("CCNYGroveTest");
								}
							}
						}
					}
					break;
				}
			}
		}
		//TryHand();
		/*
        if (floorPick() == 1)
        {
            Debug.Log ("Firstfloor array selected");
            rooms = new string[] { "Grand Hall" };

        }

        if (floorPick() == 2)
        {
            Debug.Log ("second floor array selected");
            rooms = new string[] { "Gaslamp A",
                                   "Gaslamp B",
                                   "Gaslamp C",
                                   "Gaslamp D",
                                   "La Jolla A",
                                   "La Jolla B",
                                   "Old Town A",
                                   "Old Town B",
                                   "Balbora A",
                                   "Balbora B",
                                   "Balbora C"
                                 };

        }
        if (floorPick() == 3)
        {
            Debug.Log ("third floor array selected");
            rooms = new string[] { "Torrey Hills A",
                                   "Torrey Hills B",
                                   "Golden Hill A",
                                   "Golden Hill B",

                                   "HillCrest A",
                                   "HillCrest B",
                                   "HillCrest C",
                                   "HillCrest D",
                                   "Cortez A",
                                   "Cortez B",
                                   "Cortez C",

                                   "Bankers Hill",
                                   "Mission Beach A",
                                   "Mission Beach B",
                                   "Mission Beach C",
                                   "Solana Beach A",

                                   "Solana Beach B",
                                   "Ocean Beach",
                                   "Promenade A",
                                   "Promenade B",
                                   "Pier",
                                   "Cove"
                                 };

        }
        */
	}
	
	/*public void ChangeSliderValue (Slider slider)
	{
		slider.maxValue = rooms.Length;
		for (int i = 0; i < rooms.Length; i++)
		{
			
			if ((int)slider.value == i)
			{
				choice = rooms[ (int)slider.value];
				room_text.text = "Room: " + rooms[ (int)slider.value];
				Debug.Log (rooms[ (int)slider.value]);
				EasyTTSUtil.SpeechFlush (rooms[ (int)slider.value]);
			}
		}
	}*/
	
	void introToCurrentMenu()
	{
		EasyTTSUtil.SpeechFlush("To select a path that you want to learn," +
		                        "you can swipe updown or left and right.");
	}
	
	void OnApplicationQuit()
	{
		EasyTTSUtil.Stop();
	}

	public Vector3 getStart()
	{
		return startP;
	}

	public Vector3 getEnd()
	{
		return endP;
	}
}
