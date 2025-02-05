using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScenetoMainMenu()
    {
        SceneManager.LoadScene(0) ;
    }

    public void ChangeScenetoGame()
    {
        SceneManager.LoadScene(1);
    }

}
