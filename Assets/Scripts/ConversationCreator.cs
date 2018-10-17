using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ConversationCreator : MonoBehaviour {

    public TextAsset file;
    public string conversationName = "";
    public bool readyToExecute = false;

	void Start () {
        // double check that we've been provided everything we need to parse the file
        if(readyToExecute && file == null || conversationName == "")
        {
            if (file == null)
                Debug.LogError("Please specify the file to parse.");
            else
                Debug.LogError("Please specify the conversation name");
            readyToExecute = false;
        }

        // Parse the file
        if (readyToExecute) {
            
            // split the text file into the individual lines
            string text = file.text;
            text = text.Trim('\r');
            string[] lines = text.Split('\n');

            foreach(string curLine in lines)
            {
                string line = curLine;
                Debug.Log(line);

                // if the line starts with a number --> we have a conversation line
                int convoIndex;
                string upToFirstPeriod = line.Substring(0, line.IndexOf('.'));
                if (int.TryParse(upToFirstPeriod, out convoIndex))
                {
                    // trim off the conversation index
                    line.TrimStart(upToFirstPeriod.ToCharArray());
                    
                    // check if the line ends in (EOF)

                        // remove it if it does

                    // the conversation is what remains

                    // Create the ScriptableObject
                }
                


            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
