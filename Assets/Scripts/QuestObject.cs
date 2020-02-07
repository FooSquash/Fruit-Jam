using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;

    public QuestManager questManager;

    public string startText;
    public string endText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartQuest() {
        questManager.ShowQuestText(startText);
    }

    public void EndQuest() {
        questManager.ShowQuestText(endText);
        questManager.questsCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
