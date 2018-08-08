using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestinationTrigger : MonoBehaviour {

	//TheInformationBridge 
	NextDirection infoBrg;

	public Text timerText;
	private int countColli;
	/*
	 * When avatar come into contact with a TRIGGER
	 * such as the destination cube.
	 * @param col - the trigger that was collided 
	 */ 
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("target"))
		{
			infoBrg = new NextDirection();
				//TheInformationBridge();
			infoBrg.setEndTime(timerText.text);	
			infoBrg.setNumOfCollisions(countColli);

			EasyTTSUtil.SpeechFlush("Congratulations, you've reached your destination.");
			Debug.Log("Game Over, you've completed the course");

			Invoke("changeToEndGameScene", 4); // Wait 4 seconds and then call the "changeToEndScene" Method.
		}

		if (col.gameObject.tag == "Door") 
		{
			Debug.Log ("Walking through room " + col.gameObject.name + " door");
			EasyTTSUtil.SpeechAdd("Walking through room " + col.gameObject.name + " door");
		}
	}

}
