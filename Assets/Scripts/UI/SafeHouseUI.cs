using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHouseUI : MonoBehaviour {

    private static SafeHouseUI instance;

    void Awake(){
        instance = this;
    }
    public static SafeHouseUI Instance(){
        return instance;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCraft() {
        GlobalUI.Instance().Alert("OnCraft to be implemented!");
    }

    public void OnUpgrade() {
        GlobalUI.Instance().Alert("OnUpgrade to be implemented!");
    }

    public void OnBuyAmmo() {
        GlobalUI.Instance().Alert("BuyAmmo 10 coin per ammo!");

        int _coin = PlayerState.Instance().coin;
        if(_coin >= 10)
        {
            GlobalUI.Instance().Alert("ammo +1 !");
            PlayerState.Instance().coin -= 10;
            PlayerState.Instance().ammo += 1;
        }
        else
        {
            GlobalUI.Instance().Alert("Coin not enough!");
        }

        GameManager.Instance().SyncPlayerState();

    }

    public void OnGoOut() {
        GlobalUI.Instance().Alert("Go Out!");
        GameManager.Instance().StartFight();
    }
}
