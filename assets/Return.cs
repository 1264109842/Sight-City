using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Return : MonoBehaviour {

    public Button backButton;
	// Use this for initialization
	void Start () {
        Button back = backButton.GetComponent<Button>();
        back.onClick.AddListener(ClickBack);
    }
	
    void ClickBack()
    {
        Application.LoadLevel("DifficultyControllerType");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
