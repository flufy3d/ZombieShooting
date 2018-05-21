using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour {

    private static EndingUI instance;

    void Awake(){
        instance = this;
    }
    public static EndingUI Instance(){
        return instance;
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
