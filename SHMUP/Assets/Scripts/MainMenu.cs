using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StaticFields.levelNum = 1;
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StaticFields.levelNum = 2;
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StaticFields.levelNum = 3;
    }
}
