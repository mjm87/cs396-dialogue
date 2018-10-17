using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Conversation Point", menuName = "Custom/Create Conversation Point")]
public class ConversationPoint : ScriptableObject {

	public int id;
	public string text;
	public string speaker;
	public List<Option> options;

	public List<string> GetOptions(){
		List<string> optionTexts = new List<string>();
		foreach(Option o in options){
			optionTexts.Add(o.text);
		}
		return optionTexts;
	}

	// find the chosen option from the specified text
	public ConversationPoint GetNextConversation(string optionText){
		ConversationPoint next = null;
		foreach(Option o in options){
			if(o.text == optionText) {
				next = o.next;	
			}
		}
	return next;
	}
}
