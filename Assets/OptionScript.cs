using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionScript : MonoBehaviour {

	public string optionText;
	public OptionManager manager;
	private TextMeshProUGUI text;
	
	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<TextMeshProUGUI>();
		text.text = optionText;
	}


	void OnMouseOver() {
		text.color = Color.yellow;
		Debug.Log("hovering");
	}

	void OnMouseExit() {
		text.color = Color.white;
	}
	
	void OnMouseUp(){
		// tell everybody that this is the option that was selected
		manager.SelectThisOption(optionText);
		Debug.Log("selected");
	}

	public void Remove(){
		// TODO: other cleanup??
		GameObject.Destroy(gameObject);
	}
}
