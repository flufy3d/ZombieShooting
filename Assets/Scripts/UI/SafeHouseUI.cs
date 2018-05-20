using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHouseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCraft() {
        Debug.Log("OnCraft");
    }

    public void OnUpgrade() {
        Debug.Log("OnUpgrade");
    }

    public void OnBuyAmmo() {
        Debug.Log("OnBuyAmmo");
    }

    public void OnGoOut() {
        Debug.Log("OnGoOut");
    }
}
