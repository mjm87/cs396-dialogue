using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	[SerializeField]
	private Transform optionPrefab;

	[SerializeField]
	private float optionGap = 1f;

	// list of references to all existing child optionObjects
	private Dictionary<string, OptionScript> optionObjects = new Dictionary<string, OptionScript>();

	void Start() {

		List<string> hardCodedOptions = new List<string>();
		hardCodedOptions.Add("1. Do something");
		hardCodedOptions.Add("2. Do something else");
		hardCodedOptions.Add("3. Stop worrying about it");
		hardCodedOptions.Add("4. Stop playing the game");
		hardCodedOptions.Add("1. Do something");
		
		DisplayOptions(hardCodedOptions);
	}

	public void DisplayOptions(List<string> options){

		// ClearDisplay();
		
		Vector3 spawnPosition = transform.position;
		int optionNumber = 1;

		optionObjects = new Dictionary<string, OptionScript>();
		foreach(string optionText in options){

			// create the object
			Transform optObj = Instantiate<Transform>(optionPrefab, spawnPosition, Quaternion.identity);
			optObj.parent = this.transform;
			optObj.name = "Option " + optionNumber;

			// // Assign relevant optionScript information
			// OptionScript optionScript = optObj.GetComponent<OptionScript>();
			// optionScript.optionText = optionText;
			// optionScript.manager = this;

			optObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = optionText;

			optObj.GetComponent<Button>().onClick.AddListener(delegate {
				this.SelectThisOption(optObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
			});

			// optionObjects.Add(optionText, optionScript);
			spawnPosition += Vector3.down * optionGap;
			optionNumber++;

		}
	}

	public void ClearDisplay(){
		foreach(OptionScript option in optionObjects.Values){
			option.Remove();
		}
	}

	public void SelectThisOption(string optionText) {
		// optionObjects[optionText];
		Debug.Log("Clicked on " + optionText);
	}
}
