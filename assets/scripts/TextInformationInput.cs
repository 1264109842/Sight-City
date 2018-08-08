using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextInformationInput : MonoBehaviour 
{

	public InputField name;
	public InputField title;

	GameController gamecontroller;
	TheInformationBridge infoBrg;

	string information;

	void Start ()
	{
		gamecontroller = gameObject.GetComponent<GameController> ();
		infoBrg = new TheInformationBridge ();
		information = "";
		 /*se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;*/
		
		//or simply use the line below, 
		name.onEndEdit.AddListener(SubmitName);  // This also works
		title.onEndEdit.AddListener (SubmitName);

	}
	
	void SubmitName(string s)
	{
		/*
		if (s.Length > 0)
			Debug.Log ("text has been entered");
		else
			Debug.Log ("text not entered");*/

		//information += s + "\n";
		gamecontroller.AcceptStringInput (s);
		infoBrg.setFileName (s);

	}
}
