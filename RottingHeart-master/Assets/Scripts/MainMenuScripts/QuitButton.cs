using UnityEngine;
using System.Collections;
using System;

public class QuitButton : Button
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        Application.Quit();
    }
}