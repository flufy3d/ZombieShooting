using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int ZombieID;
    private Animator ZombieAnim;
    public bool isHuman;

	// Use this for initialization
	void Start () {
		ZombieAnim = GetComponentInChildren<Animator>();
        isHuman = false;
	}
	
    public void Attack()
    {
        ZombieAnim.SetTrigger("attack");
    }

    public void BecomeHuman()
    {
        ZombieAnim.SetBool("human", true);
        isHuman = true;
    }
	// Update is called once per frame
	void Update () {

        bool allClear = true;

        Transform body = gameObject.transform.GetChild(0);
        foreach(Transform child in body)
        {

            if(child.gameObject.tag == "Parasite" && child.gameObject.activeSelf)
            {
                allClear = false;
                break;
            }

        }
        if(allClear)
            BecomeHuman();
	
	}
}
