using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwitch : MonoBehaviour 
{
    private int currentWeapon = 0;
    private int maxWeapons;
    private Animator animator;
    public static IList<Transform> weapons;
    public static int weaponsCount = 0; // add +1 to count for every additional weapon

    // Use this for initialization
    void Start()
    {
        weapons = new List<Transform>();
        AddAllWeapons();
        maxWeapons = weapons.Count;
        SelectWeapon(0);
    }

    public void AddAllWeapons()
    {
        GameObject[] gameWeapons = GameObject.FindGameObjectsWithTag("Weapon");
        
        foreach (var weapon in gameWeapons)
        {
            weapons.Add(weapon.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon + 1 <= weaponsCount)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
            SelectWeapon(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon - 1 >= 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = weaponsCount;
            }
            SelectWeapon(currentWeapon);
        }
        if (currentWeapon == weaponsCount + 1)
        {
            currentWeapon = 0;
        }
        if (currentWeapon == -1)
        {
            currentWeapon = maxWeapons;
        }

        // Assign number to every weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponsCount > 0)
        {
            currentWeapon = 1;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponsCount > 1)
        {
            currentWeapon = 2;
            SelectWeapon(currentWeapon);
        }
    }

    void SelectWeapon(int numberOfWeapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == numberOfWeapon)
            {
                //Set different animation for different weapons
                //if (weapons[i].name == "rustsword")
                //{
                //    animator.SetBool("WeaponOn", false);
                //}
                //else
                //{
                //    animator.SetBool("WeaponOn", true);
                //}
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
