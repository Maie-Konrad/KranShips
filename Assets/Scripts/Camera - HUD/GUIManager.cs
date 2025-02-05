using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{






    public void ExitProgram()
    {
        Debug.Log("Game is closing...");
        Application.Quit();

    }
    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }

}
