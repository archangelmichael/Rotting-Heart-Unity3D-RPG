using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldSwitch : MonoBehaviour
{
    private int currentShield = 0;
    private int maxShields;
    private Animator animator;
    private const int startIndexOfShields = 3;
    public static IList<Transform> shields;
    public static int shieldsCount = 0; // add +1 to count for every additional weapon

    // Use this for initialization
    void Start()
    {
        shields = new List<Transform>();
        AddAllWeapons();
        maxShields = shields.Count;
        SelectWeapon(1);
    }

    public void AddAllWeapons()
    {
        GameObject[] gameWeapons = GameObject.FindGameObjectsWithTag("Shield");

        foreach (var weapon in gameWeapons)
        {
            shields.Add(weapon.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Assign number to every weapon
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentShield = 0;
            SelectWeapon(currentShield);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && shieldsCount > 0)
        {
            currentShield = 1;
            SelectWeapon(currentShield);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && shieldsCount > 1)
        {
            currentShield = 2;
            SelectWeapon(currentShield);
        }
    }

    void SelectWeapon(int numberOfShield)
    {
        for (int i = 0; i < shields.Count; i++)
        {
            if (i == numberOfShield)
            {
                shields[i].gameObject.SetActive(true);
            }
            else
            {
                shields[i].gameObject.SetActive(false);
            }
        }
    }

}
