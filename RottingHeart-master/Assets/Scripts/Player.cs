using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Camera))]

public class Player : Skill
{
    public Camera lookAround1;
    public CharacterController charController;
    public static bool gameOver = false;
    
    private const float levelingMultiplier = 100;

    private const float maxHealth = 10000;
    public static float currentHealth;
    public const float HealthBarMax = maxHealth;

    private float healthbarLength;

    private static bool playerIsDead = false;
    
    private static int level = 1;
    private static float experience = 0;

    public static float Experience
    {
        get { return Player.experience; }
        set { Player.experience = value; }
    }
    public static int Level
    {
        get { return Player.level; }
        set { Player.level = value; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public static bool PlayerIsDead
    {
        get { return Player.playerIsDead; }
        set { Player.playerIsDead = value; }
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthbarLength = Screen.width / 2;
    }
    void Update()
    {
        if (Experience >= level * levelingMultiplier)
        {
            experience -= levelingMultiplier * Level;
            Level++;
            Melee.DamageCoef += 0.2f;
        }

        AdjustCurrentHealth(0);
        if (playerIsDead)
        {
            lookAround1.enabled = false;
            charController.enabled = false;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / currentHealth), 20), currentHealth + "/" + maxHealth);
        GUI.Box(new Rect(10, Screen.height - 40, Screen.width / 4, 20), "Level " + level);
        GUI.Box(new Rect(10, Screen.height - 20, Screen.width / 4, 20), "Experience " + experience + "/" + levelingMultiplier * level);
    
        if (playerIsDead)
        {
            // Make a background box
            GUI.Box(new Rect(Screen.width/2 , Screen.height / 2, 150, 100), "You have been killed!");
            // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 20, 80, 20), "Respawn"))
            {
                RespawnPlayer();
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 40, 80, 20), "Exit Game"))
            {
                Application.LoadLevel(2);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 20, 80, 20), "Respawn"))
            {
                RespawnPlayer();
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 40, 80, 20), "Exit Game"))
            {
                Application.LoadLevel(2);
            }
        }
        if (gameOver)
        {
            int positionEdit = 100;
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - positionEdit, 150, 100), "THE END!");
            if (GUI.Button(new Rect(Screen.width / 2 + 1, Screen.height / 2 - positionEdit + 20, 100, 20), "Restart Gaem"))
            {
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 1, Screen.height / 2 - positionEdit + 40, 100, 20), "Exit Game"))
            {
                Application.LoadLevel(2);
            }
        }
    }

    public void AdjustCurrentHealth(float adj)
    {
        currentHealth += adj;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        healthbarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }

    void Damage(float damage) // Applies damage when hit
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        playerIsDead = true;
        animation.CrossFade("die");
    }

    void RespawnPlayer()
    {
        //transform.position = respawnLocation.position;
        //transform.rotation = respawnLocation.rotation;
        //gameObject.SendMessage("RespawnStats");
        playerIsDead = false;
        currentHealth = maxHealth;
        lookAround1.enabled = true;
        charController.enabled = true;
        Application.LoadLevel(1);
    }
    
}
