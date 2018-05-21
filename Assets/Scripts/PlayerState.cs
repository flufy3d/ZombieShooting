using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    private static PlayerState instance;

    void Awake(){
        instance = this;
    }
    public static PlayerState Instance(){
        return instance;
    }

    public int days = 0;
    public int health = 100;
    public int ammo = 0;
    public int coin = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
