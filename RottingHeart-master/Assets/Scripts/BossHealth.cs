using UnityEngine;
using System.Collections;

public class BossHealth : EnemyHealth 
{
    public override void Dead()
    {
        base.Dead();
        if (gameObject.tag == "Boss")
        {
            Quests.QuestStarted = 1;
            Quests.TaskCompleted = 1;
            Player.Experience += 300;
        }
        else if (gameObject.tag == "Boss2")
        {
            Quests.QuestStarted = 2;
            Quests.TaskCompleted = 1;
            Player.Experience += 500;
        }
        else if (gameObject.tag == "Boss3")
        {
            Quests.QuestStarted = 3;
            Quests.TaskCompleted = 1;
            Player.Experience += 1000;
        }
        WeaponSwitch.weaponsCount++;
        ShieldSwitch.shieldsCount++;

    }
	
}
