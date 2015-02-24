using UnityEngine;
using System.Collections;

public class Quests : MonoBehaviour
{

    private static int questStarted = 0;
    private static int questCompleted = 0;
    private static int taskCompleted = 0;

    public static int QuestStarted
    {
        get
        {
            return questStarted;
        }
        set
        {
            questStarted = value;
        }
    }

    public static int QuestCompleted
    {
        get
        {
            return questCompleted;
        }
        set
        {
            questCompleted = value;
        }
    }

    public static int TaskCompleted
    {
        get
        {
            return taskCompleted;
        }
        set
        {
            taskCompleted = value;
        }
    }


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
