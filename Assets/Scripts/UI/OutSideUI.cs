using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSideUI : MonoBehaviour {

    public Animator panelControl;
    private string prevState;
    private string state;
	// Use this for initialization
	void Start () {
        prevState = "hide";
        state = "hide";
	}
	
	// Update is called once per frame
	void Update () {
		
        Vector2 mouseOnScreenPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (mouseOnScreenPos.y < 0.15f)
        {
            state = "show";
            if(prevState == "hide")
                panelControl.SetTrigger("show");
            
        }
        else
        {
            state = "hide";
            if(prevState == "show")
                panelControl.SetTrigger("hide");
            
        }

        prevState = state;
	}
}
