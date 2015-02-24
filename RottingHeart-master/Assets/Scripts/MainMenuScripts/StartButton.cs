using UnityEngine;
using System.Collections;

public class StartButton : Button
{

    // ------------------------------------------
    // change the text color when button pointed
    public override void OnMouseEnter()
    {
        renderer.material.color = Color.green;
    }

    public override void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    // ------------------------------------------
    // load the game on mouse click
    public override void OnMouseDown()
    {
        Application.LoadLevel("LevelOne");
    }
}