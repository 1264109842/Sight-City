using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON2;
using System.IO;
//using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
	public Button generalTutorial, trainingTutorial, trainingMode, gameMode, CalculatPath;

	GameController1 gameController;
	private int selection;
	TheInformationBridge inforBrg;
	RoomLocationsConf roomLoc;
	
	void Start()
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);
		gameController = gameObject.GetComponent<GameController1> ();
		Button gT = generalTutorial.GetComponent<Button> ();
		Button tT = trainingTutorial.GetComponent<Button> ();
		Button tM = trainingMode.GetComponent<Button> ();
		Button gM = gameMode.GetComponent<Button> ();
		Button calPath = CalculatPath.GetComponent<Button> ();

		selection = 0;
		inforBrg = new TheInformationBridge ();
		roomLoc = new RoomLocationsConf ();

		
		
		gT.onClick.AddListener (ClickGeneralTutorial);
		tT.onClick.AddListener (ClickTrainingTutorial);
		tM.onClick.AddListener (ClickTrainingMode);
		gM.onClick.AddListener (ClickGameMode);
		calPath.onClick.AddListener (ClickCalPath);
		
	}
	
	void Update()
	{

	}

	void ClickCalPath()
	{
		inforBrg.setAutoGenerateStates(true);
		roomLoc.getStartingPoint (new Vector3(44f,2f,138.7f));
		roomLoc.getEndingPoint (new Vector3(44f,2f,138.7f));
		Application.LoadLevel ("CCNYGrove");
	}
	
	void ClickGeneralTutorial()
	{

		EasyTTSUtil.SpeechAdd ("General tutorial");
		Debug.Log ("General tutorial");
		StartCoroutine (MyCoroutine());
		if(selection > 0)
			Application.LoadLevel ("GeneralTutorial");
		selection ++;
	}

	void ClickTrainingTutorial()
	{

		EasyTTSUtil.SpeechAdd ("Training mode tutorial");
		Debug.Log ("Training mode tutorial");
		StartCoroutine (MyCoroutine());
		if(selection > 0)
			Application.LoadLevel ("TrainingModeTutorial");
		selection ++;
	}

	void ClickTrainingMode()
	{

		EasyTTSUtil.SpeechAdd ("Training mode");
		Debug.Log ("Training model");
		StartCoroutine (MyCoroutine());
		if(selection > 0)
			Application.LoadLevel ("DifficultyControllerType");
		selection ++;
	}

	void ClickGameMode(){
		EasyTTSUtil.SpeechAdd ("Game mode");
        Debug.Log("Game Mode");
        StartCoroutine(MyCoroutine());
        if (selection > 0)
            Application.LoadLevel("DemoLevel");
        selection++;
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