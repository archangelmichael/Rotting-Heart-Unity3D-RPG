using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class Questgiver : MonoBehaviour {

    public Rect windowRect = new Rect(20, 20, 120, 50);
 
  
  	// Use this for initialization
	void Start ()
    {
                      
	}
	
	// Update is called once per frame
	void OnGUI()
    {

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 7)
        {

            switch (Quests.QuestCompleted)
            {
                case 0: FirstQuest(); break;
                case 1: SecondQuest(); break;
                case 2: ThirdQuest(); break;
                default:
                    {
                        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 130, 100), "Spectacular WIN!\nThis Ends our\nDEMO");
                        Player.gameOver = true;
                    }
                    break;
            }
            
        }
        
	}

    
    static void FirstQuest()
    {
            Quests.QuestStarted = 1;

            if (Quests.QuestStarted == 1 && Quests.TaskCompleted == 1)
            {
                Quests.TaskCompleted = 0;
                Quests.QuestCompleted = 1;
                return;
            }
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 130, 100), "Go kill that terrible\ncreature outside\nthe cemetary gates\nand i shall \nreward you greatly.");
    }

    static void SecondQuest()
    {
        Quests.QuestStarted = 2;
        if (Quests.QuestStarted == 2 && Quests.TaskCompleted == 1)
        {
            
            Quests.TaskCompleted = 0;
            Quests.QuestCompleted = 2;
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 130, 100), "");
            return;
        }

        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 150, 150), "Very nice, great job!\nYou are our\nnew hero, bones!\nMany more creatures\nare coming this way!\nThey have their boss\nWe need you once\nagain. HELP US!\nKill that big boss!");
        
    }

    static void ThirdQuest()
    {
        
        Quests.QuestStarted = 3;
      
        if (Quests.QuestStarted == 3 && Quests.TaskCompleted == 1)
        {
            Quests.QuestCompleted = 3;
            
            return;
        }

        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 170, 170), "Tremendous job!\nYou have proven yourself\nonce more\nand we are forever\nin your debt.\nThose monsters are!\nsent to us by the\nterrible skeleton lord\nso you need to\ngo finish him off.");
        
    }

}
