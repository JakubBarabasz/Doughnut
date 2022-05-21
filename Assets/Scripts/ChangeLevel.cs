using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public void ChangeLevels(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
