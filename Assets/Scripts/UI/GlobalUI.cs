using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUI : MonoBehaviour {

    private static GlobalUI instance;
    public Text alertText;

    public Text daysText;
    public Slider healthSlider;
    public Text ammoText;
    public Text coinText;

    private Queue<string> messageList = new Queue<string>();

    void Awake(){
        instance = this;
    }
    public static GlobalUI Instance(){
        return instance;
    }


    IEnumerator ProcessMessageList()
    {
        while(true)
        {
            if(messageList.Count != 0)
            {
                string message = messageList.Dequeue();
                alertText.text = message;  
            }

            yield return new WaitForSeconds(0.2f);
        }
        
    }

	// Use this for initialization
	void Start () {
		StartCoroutine(ProcessMessageList());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Alert(string message)
    {
        //alertText.text = message;
        messageList.Enqueue(message);
    }

    public void SetDays(int day)
    {
        daysText.text = "Day: " + day;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetAmmo(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }

    public void SetCoin(int coin)
    {
        coinText.text = "Coin: " + coin;
    }
}
