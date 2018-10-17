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
	private Dictionary<string, Transform> optionObjects = new Dictionary<string, Transform>();

	public string selectedOption = "";

	void Start() {


	//TODO: remove after testing
		List<string> hardCodedOptions = new List<string>();
		hardCodedOptions.Add("1. Do something");
		hardCodedOptions.Add("2. Do something else");
		hardCodedOptions.Add("3. Stop worrying about it");
		hardCodedOptions.Add("4. Stop playing the game");
		
		// DisplayOptions(hardCodedOptions);

	}

	public void DisplayOptions(List<string> options){

		ClearDisplay();
		selectedOption = "";
		
		Vector3 spawnPosition = transform.position;
		int optionNumber = 1;

		optionObjects = new Dictionary<string, Transform>();
		foreach(string optionTextString in options){

			string optionText = optionTextString;
			// string optionText = "  " + optionTextString;

			// create the object
			Transform optObj = Instantiate<Transform>(optionPrefab, spawnPosition, Quaternion.identity);
			optObj.parent = this.transform;
			optObj.name = "Option " + optionNumber;
			setTransformRectWidth(optObj.gameObject, 18 * optionText.Length);		
				// TODO: account for extra padding left over thanks to non-monospaced fonts

			// assign the object text
			optObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = optionText;

			// assign the callback function for selection
			optObj.GetComponent<Button>().onClick.AddListener(delegate {
				this.SelectThisOption(optObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
			});

			// save off object reference
			optionObjects.Add(optionText, optObj);

			// go to next option
			spawnPosition += Vector3.down * optionGap;
			optionNumber++;

		}
	}

	public void ClearDisplay(){
		foreach(Transform option in optionObjects.Values){
			GameObject.Destroy(option.gameObject);
		}
		optionObjects = new Dictionary<string, Transform>();
	}

	public void SelectThisOption(string optionText) {
		selectedOption = optionText; 
		ClearDisplay();
	}

	private void setTransformRectWidth(GameObject obj, float width) {
		// obj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(
		// 	RectTransform.Axis.Horizontal, 
		// 	width
		// );
		float height = obj.GetComponent<RectTransform>().sizeDelta.y;
		obj.GetComponent<RectTransform>().sizeDelta = new Vector3(width, height);
		obj.transform.Translate(Vector3.right * width/2);

	}
}
