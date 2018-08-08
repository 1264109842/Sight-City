using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON2;
using System.IO;
//using UnityEditor;
//using UnityEngine.SceneManagement;

public class TopMenu : MonoBehaviour
{
	public Button levelOne, levelTwo,levelThree, levelFour, confirmButton, backButton;
	public Text level, numLevelOne, numLevelTwo, numLevelThree, numLevelFour;
	public InputField selectNum;
	string selectLevel;
	JSONNode json;
	Vector3 startPos;
	Vector3 endPos;
	int rand;
	RoomLocationsConf roomLoc;
	RuntimePlatform platform = Application.platform;
	TheInformationBridge inforBrg;
	GameController1 gameController;
	private int selection;
	private int numberOfItem;

	void Start()
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);

		gameController = gameObject.GetComponent<GameController1> ();
		Button one = levelOne.GetComponent<Button> ();
		Button two = levelTwo.GetComponent<Button> ();
		Button three = levelThree.GetComponent<Button> ();
		Button four = levelFour.GetComponent<Button> ();
		Button confirm = confirmButton.GetComponent<Button> ();
        Button back = backButton.GetComponent<Button>();
		Text lvone = numLevelOne.GetComponent<Text> ();
		Text lvtwo = numLevelTwo.GetComponent<Text> ();
		Text lvthree = numLevelThree.GetComponent<Text> ();
		Text lvfour = numLevelFour.GetComponent<Text> ();


		inforBrg = new TheInformationBridge ();
		selection = 0;




		/*string path = Application.persistentDataPath + "/LevleSave.json";

		string jsonString = File.ReadAllText (path);
		Debug.Log (jsonString);
		json = (JSONNode)JSON.Parse (jsonString);*/
		roomLoc = new RoomLocationsConf ();

		try
		{
			//EasyTTSUtil.SpeechAdd("try to catch the exception");
			inforBrg.setAutoGenerateStates(false);
			string path = Application.persistentDataPath + "/LevleSave.json";
			//EasyTTSUtil.SpeechAdd("one");
			string jsonString = "";
			//if (platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
				jsonString = File.ReadAllText (path);
			/*if (platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer)
				jsonString = File.ReadAllText (path);
			if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
				TextAsset jsonTxt = (TextAsset)Resources.Load("LevleSave",typeof(JSON));
				jsonString = jsonTxt.text;
			}*/
			//EasyTTSUtil.SpeechAdd("two");
			//Debug.Log (jsonString);
			json = (JSONNode)JSON.Parse (jsonString);

			print (json ["Level One"] ["End"].Count + ".");
		
			lvone.text = json ["Level One"] ["End"].Count + ".";
			lvtwo.text = json ["Level two"] ["End"].Count + ".";
			lvthree.text = json ["Level three"] ["End"].Count + ".";
			lvfour.text = json ["Level four"] ["End"].Count + ".";
		}catch(FileNotFoundException e)
		{
			//EasyTTSUtil.SpeechAdd("catch the exceptoption");
			inforBrg.setAutoGenerateStates(true);
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(44f,2f,138.7f));
			Application.LoadLevel ("CCNYGrove");
		}




		selectNum.onEndEdit.AddListener (SelectNumber);
		one.onClick.AddListener (ClickOne);
		two.onClick.AddListener (ClickTwo);
		three.onClick.AddListener (ClickThree);
		four.onClick.AddListener (ClickFour);
		confirm.onClick.AddListener (Confirm);
        back.onClick.AddListener(ClickBack);

	
	}

    void Update()
    {
		Text lv = level.GetComponent<Text> ();
		lv.text = selectLevel;

    }
	

	void SelectNumber(string select)
	{
		///(int)select
		Debug.Log (int.Parse(select));
		numberOfItem = int.Parse (select);
		//select.
	}

	void ClickOne()
	{
		EasyTTSUtil.SpeechAdd ("Level one");
		selectLevel = "Level One";
	}

	void ClickTwo()
	{
		EasyTTSUtil.SpeechAdd ("Level two");
		selectLevel = "Level two";
	}

	void ClickThree()
	{
		EasyTTSUtil.SpeechAdd ("Level three");
		selectLevel = "Level three";
	}

	void ClickFour()
	{
		EasyTTSUtil.SpeechAdd ("Level four");
		selectLevel = "Level four";
	}

    void ClickBack()
    {
        EasyTTSUtil.SpeechAdd("Back");
        Application.LoadLevel("1ModeSelect");
    }

	void Confirm()
	{
		if (selectLevel != null) {
			/*string path = Application.persistentDataPath + "/LevleSave.json";
		
			string jsonString = File.ReadAllText (path);
			Debug.Log (jsonString);
			json = (JSONNode)JSON.Parse (jsonString);*/
			Debug.Log ("Level selection"+ selectLevel);
			Debug.Log (json [selectLevel] ["Start"] [0] [0].AsFloat);
			Debug.Log (json [selectLevel] ["End"].Count);
			//rand = (int)Random.Range (0, json ["Level One"] ["End"].Count);
			
			startPos.x = json [selectLevel] ["Start"] [numberOfItem-1] [0].AsFloat;
			startPos.y = json [selectLevel] ["Start"] [numberOfItem-1] [1].AsFloat;
			startPos.z = json [selectLevel] ["Start"] [numberOfItem-1] [2].AsFloat;
			endPos.x = json [selectLevel] ["End"] [numberOfItem-1] [0].AsFloat;
			endPos.y = json [selectLevel] ["End"] [numberOfItem-1] [1].AsFloat;
			endPos.z = json [selectLevel] ["End"] [numberOfItem-1] [2].AsFloat;
			Debug.Log (startPos);
			Debug.Log (endPos);
			
			
			roomLoc.getStartingPoint (startPos);
			roomLoc.getEndingPoint (endPos);
			Application.LoadLevel ("CCNYGrove");
		} else {
			inforBrg.setAutoGenerateStates(true);
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(44f,2f,138.7f));
			Application.LoadLevel ("CCNYGrove");
		}
	}

	private IEnumerator MyCoroutine()
	{
		//This is a coroutine
		Debug.Log (Time.time);
		
		yield return new WaitForSeconds (1.5f);    //Wait one frame
		selection--;
		Debug.Log ("waiting  time ");
		
	}

}