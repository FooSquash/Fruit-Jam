using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;

    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        dialogueBox.SetActive(false);
        dialogueActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
            //dialogueBox.SetActive(false);
            //dialogueActive = false;
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length) {
            dialogueBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
        }

        dialogueText.text = dialogueLines[currentLine];
	}

    public void ShowBox(string dialogue) {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }

    public void ShowDialogue() {
        dialogueActive = true;
        dialogueBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
