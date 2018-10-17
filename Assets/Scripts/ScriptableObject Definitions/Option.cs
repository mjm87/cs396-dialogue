using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Option", menuName = "Custom/Create Conversation Option")]
public class Option : ScriptableObject {
	public string text;
	public ConversationPoint next;
}