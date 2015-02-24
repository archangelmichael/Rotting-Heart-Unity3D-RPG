using UnityEngine;
using System.Collections;

public class GameOver : Button, IButton
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public override void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    public override void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    // quit the game on mouse click
    public override void OnMouseDown()
    {
        Application.LoadLevel(2);
    }
}
