using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEffectUI : MonoBehaviour {

    private static HurtEffectUI instance;

    void Awake(){
        instance = this;
    }
    public static HurtEffectUI Instance(){
        return instance;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
