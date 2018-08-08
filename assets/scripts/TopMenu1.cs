using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON2;
using System.IO;
//using UnityEngine.SceneManagement;

public class TopMenu1 : MonoBehaviour
{
	public Button levelOne, levelTwo,levelThree, levelFour, IsAutoGenerate;
	public Text level, numLevelOne, numLevelTwo, numLevelThree, numLevelFour;
	public InputField selectNum;
	ColorBlock cb;
	string s;
	JSONNode json;
	Vector3 startPos;
	Vector3 endPos;
	int rand;
	RoomLocationsConf roomLoc;
	bool isGenerate;
	TheInformationBridge inforBrg;
	GameController1 gameController;
	private int selection;

	void Start()
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);

		string path = Application.persistentDataPath + "/LevleSave.json";
		
		string jsonString = File.ReadAllText (path);
		Debug.Log (jsonString);
		json = (JSONNode)JSON.Parse (jsonString);

		gameController = gameObject.GetComponent<GameController1> ();
		Button one = levelOne.GetComponent<Button> ();
		Button two = levelTwo.GetComponent<Button> ();
		Button three = levelThree.GetComponent<Button> ();
		Button four = levelFour.GetComponent<Button> ();
		Text lvone = numLevelOne.GetComponent<Text> ();
		Text lvtwo = numLevelTwo.GetComponent<Text> ();
		Text lvthree = numLevelThree.GetComponent<Text> ();
		Text lvfour = numLevelFour.GetComponent<Text> ();


		print (json ["Level One"] ["End"].Count + ".");

		lvone.text = json ["Level One"] ["End"].Count + ".";
		lvtwo.text = json ["Level two"] ["End"].Count + ".";
		lvthree.text = json ["Level three"] ["End"].Count + ".";
		lvfour.text = json ["Level four"] ["End"].Count + ".";

		inforBrg = new TheInformationBridge ();
		selection = 0;


		isGenerate = true;


		/*string path = Application.persistentDataPath + "/LevleSave.json";

		string jsonString = File.ReadAllText (path);
		Debug.Log (jsonString);
		json = (JSONNode)JSON.Parse (jsonString);*/
		roomLoc = new RoomLocationsConf ();


		one.onClick.AddListener (ClickOne);
		two.onClick.AddListener (ClickTwo);
		three.onClick.AddListener (ClickThree);
		four.onClick.AddListener (ClickFour);

	
	}

    void Update()
    {
		Text lv = level.GetComponent<Text> ();
		lv.text = s;
		Button b = IsAutoGenerate.GetComponent<Button> ();
		if (isGenerate == false) {
			cb = b.colors;
			cb.highlightedColor = Color.green;
			b.colors = cb;
		} else {
			cb = b.colors;
			cb.highlightedColor = Color.gray;
			b.colors = cb;
		}
		b.onClick.AddListener (GeneratePath);
    }

	void GeneratePath()
	{
		if (isGenerate == false) {
			inforBrg.setAutoGenerateStates(isGenerate);
			isGenerate = !isGenerate;
		} else {
			inforBrg.setAutoGenerateStates(isGenerate);
			isGenerate = !isGenerate;
		}
	}

	void ClickOne()
	{
		EasyTTSUtil.SpeechAdd ("Level one");
		s = "Level One";
		if (isGenerate) {
			/*string path = Application.persistentDataPath + "/LevleSave.json";
		
			string jsonString = File.ReadAllText (path);
			Debug.Log (jsonString);
			json = (JSONNode)JSON.Parse (jsonString);*/
			Debug.Log ("Level one");
			Debug.Log (json ["Level One"] ["Start"] [0] [0].AsFloat);
			Debug.Log (json ["Level One"] ["End"].Count);
			rand = (int)Random.Range (0, json ["Level One"] ["End"].Count);

			startPos.x = json ["Level One"] ["Start"] [rand] [0].AsFloat;
			startPos.y = json ["Level One"] ["Start"] [rand] [1].AsFloat;
			startPos.z = json ["Level One"] ["Start"] [rand] [2].AsFloat;
			endPos.x = json ["Level One"] ["End"] [rand] [0].AsFloat;
			endPos.y = json ["Level One"] ["End"] [rand] [1].AsFloat;
			endPos.z = json ["Level One"] ["End"] [rand] [2].AsFloat;
			Debug.Log (startPos);
			Debug.Log (endPos);


			roomLoc.getStartingPoint (startPos);
			roomLoc.getEndingPoint (endPos);
			Application.LoadLevel ("CCNYGrove");
		} else {
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(-62.6f,2f,168.5f));
			Application.LoadLevel ("CCNYGrove");
		}

	}

	void ClickTwo()
	{
		EasyTTSUtil.SpeechAdd ("Level two");
		s = "Level two";
		if (isGenerate) {

			Debug.Log ("Level two");
			Debug.Log (json["Level two"]["Start"][0][0].AsFloat);
			Debug.Log (json["Level two"]["End"].Count);
			rand = (int)Random.Range (0,json["Level two"]["End"].Count);
		
			startPos.x = json["Level two"]["Start"][rand][0].AsFloat;
			startPos.y = json["Level two"]["Start"][rand][1].AsFloat;
			startPos.z = json["Level two"]["Start"][rand][2].AsFloat;
			endPos.x = json["Level two"]["End"][rand][0].AsFloat;
			endPos.y = json["Level two"]["End"][rand][1].AsFloat;
			endPos.z = json["Level two"]["End"][rand][2].AsFloat;
			Debug.Log (startPos);
			Debug.Log (endPos);
			roomLoc.getStartingPoint (startPos);
			roomLoc.getEndingPoint (endPos);
			Application.LoadLevel ("CCNYGrove");
		} else {
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(-62.6f,2f,168.5f));
			Application.LoadLevel ("CCNYGrove");
		}
	}

	void ClickThree()
	{
		EasyTTSUtil.SpeechAdd ("Level three");
		s = "Level three";
		if (isGenerate) {

			Debug.Log ("Level three");
			Debug.Log (json ["Level three"] ["Start"] [0] [0].AsFloat);
			Debug.Log (json ["Level three"] ["End"].Count);
			rand = (int)Random.Range (0, json ["Level three"] ["End"].Count);
		
			startPos.x = json ["Level three"] ["Start"] [rand] [0].AsFloat;
			startPos.y = json ["Level three"] ["Start"] [rand] [1].AsFloat;
			startPos.z = json ["Level three"] ["Start"] [rand] [2].AsFloat;
			endPos.x = json ["Level three"] ["End"] [rand] [0].AsFloat;
			endPos.y = json ["Level three"] ["End"] [rand] [1].AsFloat;
			endPos.z = json ["Level three"] ["End"] [rand] [2].AsFloat;
			Debug.Log (startPos);
			Debug.Log (endPos);
			roomLoc.getStartingPoint (startPos);
			roomLoc.getEndingPoint (endPos);
			Application.LoadLevel ("CCNYGrove");
		} else {
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(-62.6f,2f,168.5f));
			Application.LoadLevel ("CCNYGrove");
		}
	}

	void ClickFour()
	{
		EasyTTSUtil.SpeechAdd ("Level four");
		s = "Level four";
		if (isGenerate) {

			Debug.Log ("Level four");
			Debug.Log (json ["Level four"] ["Start"] [0] [0].AsFloat);
			Debug.Log (json ["Level four"] ["End"].Count);
			rand = (int)Random.Range (0, json ["Level four"] ["End"].Count);
		
			startPos.x = json ["Level four"] ["Start"] [rand] [0].AsFloat;
			startPos.y = json ["Level four"] ["Start"] [rand] [1].AsFloat;
			startPos.z = json ["Level four"] ["Start"] [rand] [2].AsFloat;
			endPos.x = json ["Level four"] ["End"] [rand] [0].AsFloat;
			endPos.y = json ["Level four"] ["End"] [rand] [1].AsFloat;
			endPos.z = json ["Level four"] ["End"] [rand] [2].AsFloat;
			Debug.Log (startPos);
			Debug.Log (endPos);
			roomLoc.getStartingPoint (startPos);
			roomLoc.getEndingPoint (endPos);
			Application.LoadLevel ("CCNYGrove");
		} else {
			roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
			roomLoc.getEndingPoint (new Vector3(-62.6f,2f,168.5f));
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