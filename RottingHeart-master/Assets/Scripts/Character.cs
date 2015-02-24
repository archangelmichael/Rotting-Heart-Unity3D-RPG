using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
    private string name;

    public Character(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
}
