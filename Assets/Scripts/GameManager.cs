using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Zombie EnemyPrefab;
    public int EnemyCount;

    private static GameManager instance;
    public static GameManager Instance(){
        return instance;
    }
	// Use this for initialization
    void Awake()
    {
        instance = this;

        //enable all ui element convenient for singleton implement
        foreach (Transform child in GameObject.Find("Canvas").transform)
        {
            child.gameObject.SetActive(true);
        }

    }
    void ShowOutSideUI()
    {
        HurtEffectUI.Instance().gameObject.SetActive(false);
        EndingUI.Instance().gameObject.SetActive(false);
        SafeHouseUI.Instance().gameObject.SetActive(false);

        OutSideUI.Instance().gameObject.SetActive(true);
        GlobalUI.Instance().gameObject.SetActive(true);    
    }
    void ShowSafeHouseUI()
    {
        HurtEffectUI.Instance().gameObject.SetActive(false);
        EndingUI.Instance().gameObject.SetActive(false);
        OutSideUI.Instance().gameObject.SetActive(false);

        SafeHouseUI.Instance().gameObject.SetActive(true);
        GlobalUI.Instance().gameObject.SetActive(true);     
    }

    public void SyncPlayerState()
    {
        GlobalUI.Instance().SetDays(PlayerState.Instance().days);
        GlobalUI.Instance().SetHealth(PlayerState.Instance().health);
        GlobalUI.Instance().SetAmmo(PlayerState.Instance().ammo);
        GlobalUI.Instance().SetCoin(PlayerState.Instance().coin);
    }


    private IEnumerator LoadSceneAndSetActive (string sceneName)
    {
        // Allow the given scene to load over several frames and add it to the already loaded scenes (just the Persistent scene at this point).
        yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

        // Find the scene that was most recently loaded (the one at the last index of the loaded scenes).
        Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);

        // Set the newly loaded scene as the active scene (this marks it as the one to be unloaded next).
        SceneManager.SetActiveScene (newlyLoadedScene);

    }

    private IEnumerator FadeAndSwitchScenes (string sceneName)
    {

        // Unload the current active scene.
        yield return SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

        // Start loading the given scene and wait for it to finish.
        yield return StartCoroutine (LoadSceneAndSetActive (sceneName));

    }

    public void SwitchScenes(string sceneName)
    {
        StartCoroutine (FadeAndSwitchScenes (sceneName));
    }

    private void CreateEnemies(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Vector3 position;
            position.y = -0.76f;
            position.z = -1.64f + i * 0.5f;
            position.x = -0.17f - i * 0.5f;

            Zombie _zombie = (Zombie)Instantiate(EnemyPrefab, position , Quaternion.identity);

            _zombie.ZombieID = i;
            _zombie.transform.parent = gameObject.transform;

        }
    }

    private IEnumerator ProcessEnemiesMove ()
    {
        yield return null;
    }
  

    public void StartFight()
    {
        SwitchScenes("FightScene");
        GlobalUI.Instance().Alert("Start Fight!");
        ShowOutSideUI();
        //EnemyCount = PlayerState.Instance().days + 1;
        EnemyCount = 4;
        CreateEnemies(EnemyCount);
    }
	void Start () {

        ShowSafeHouseUI();
        SyncPlayerState();
        StartCoroutine (LoadSceneAndSetActive ("SafeHouse"));
	}
	
	// Update is called once per frame
	void Update () {
      
		
	}
}
