using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;


[InitializeOnLoad]
public class Startup {
    static Startup()
    {
        Debug.Log("Set Default PlayMode Scene!");
        string scenePath = "Assets/Scenes/persistent.unity";
        SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        if (myWantedStartScene != null)
            EditorSceneManager.playModeStartScene = myWantedStartScene;
        else
            Debug.Log("Could not find scene " + scenePath);
    }
}

static class SceneAutoLoader
{

    [MenuItem("Scene Autoload/Select Master Scene...")]
    public static void SelectStartupScene()
    {
        string masterScene = EditorUtility.OpenFilePanel("Select Master Scene", Application.dataPath, "unity");
        masterScene = masterScene.Replace(Application.dataPath, "Assets");
        if (!string.IsNullOrEmpty(masterScene))
        {
            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(masterScene);
        }
    }

    [MenuItem("Scene Autoload/Disable Scene Autoload")]
    public static void DisableSceneAutoload(){
        EditorSceneManager.playModeStartScene = null;
    }
}  