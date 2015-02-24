using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour, ISkillable
{
    private float time = 0;
    private const float cooldown = 4;
    private const float healing = 300;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Heal Me!");
            if (time >= cooldown)
            {
                Debug.Log("Now");
                CastSkill();
                time = 0;
            }
            else
            {
                Debug.Log("Cooldown");
                time += 0.5f;
            }
        }
	}

    public void CastSkill()
    {
        if ( Player.currentHealth + healing <= Player.HealthBarMax)
        {
            Player.currentHealth += healing;
        }
    }
}
