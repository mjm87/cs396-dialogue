using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour {

	[SerializeField]
	private GameObject conversationPane, dialogueChoices;

	private OptionManager manager;
	private TextMeshProUGUI conversation;

	private bool done = true;

	[SerializeField]
	private ConversationPoint storyStarter;

	void Start () {

		// init
		conversation = conversationPane.GetComponent<TextMeshProUGUI>();
		manager = dialogueChoices.GetComponent<OptionManager>();

		StartCoroutine(PlayConversation(storyStarter));
	}

	private IEnumerator PlayConversation(ConversationPoint conversationPoint){

		// reveal the next point in the conversation
		StartCoroutine(reveal(conversationPoint.text));
		yield return new WaitUntil(() => done);
 
		// check that we have new options to explore
		if(conversationPoint.options.Count > 0) {

			// display the options
			manager.DisplayOptions(conversationPoint.GetOptions());

			// wait for an option to be selected
			yield return new WaitUntil(() => anOptionHasBeenSelected());

			Debug.Log("Selected: " + manager.selectedOption);
			conversation.text = "";

			// recursively start over with the next conversation point
			ConversationPoint nextConversation = conversationPoint.GetNextConversation(manager.selectedOption);
			if(nextConversation != null) {
				StartCoroutine(PlayConversation(nextConversation));
			}	

		}
	}

	private IEnumerator reveal(string message){
		done = false;
		conversation.text = "";
		foreach(char c in message) {
			conversation.text += c;
			if(!Input.anyKey) {
				yield return new WaitForSeconds(0.1f);
			}
		}
		done = true;
		yield return new WaitForEndOfFrame();
	}
	
	private bool anOptionHasBeenSelected(){
		return manager.selectedOption != "";
	}

	private List<string> getHardCodedDialogue(){
		List<string> options = new List<string>();
		options.Add("Have you reconsidered?");
		options.Add("It's just as well I suppose...");
		options.Add("I wouldn't say such things if I were you!");
		return options;
	}
}
