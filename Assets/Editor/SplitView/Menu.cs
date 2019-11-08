using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UIRootObject;
    private AsyncOperation sceneAsync;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// _w 单一的快捷键 W
    /// #w shift + w
    /// %w ctrl + w
    /// &w alt + w
    /// </summary>
    [MenuItem("SplitView/AddSplitCamera")]
    public static void AddSplitCamera()
    {
        Debug.Log("Test_-----");
        Scene scene = EditorSceneManager.OpenScene("Assets/scene/pluginScene.unity", OpenSceneMode.Additive);
        //EditorSceneManager.GetSceneByPath
        //Scene scene = EditorSceneManager.OpenScene("Assets/scene/pluginScene.unity", OpenSceneMode.Additive);
        //Scene scene = SceneManager.GetActiveScene();
        //Scene s = SceneManager.GetSceneByName("pluginScene");
        //if (s.IsValid())
        //{
        //    Debug.Log("Scene is Valid");
        //}
        //while (scene.progress < 0.9f)
        //{
        //    Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
        //}
        Debug.Log("Test_-----3");
        //Scene s = SceneManager.GetSceneByPath("Assets/scene/pluginScene.unity");
        GameObject[] objs = scene.GetRootGameObjects();
        Debug.Log(objs.Length);
        //EditorSceneManager.CloseScene(scene, true);
        GameObject plugin = objs[0];
        GameObject www = Instantiate(plugin) as GameObject;
        www.SetActive(true);
        ////Scene scene = SceneManager.GetActiveScene();
        EditorSceneManager.CloseScene(scene, true);
        Debug.Log("Test_-----2");
    }
}
