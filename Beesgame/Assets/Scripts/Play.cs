﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {


        UnityEngine.SceneManagement.SceneManager.LoadScene("BeeGames");
    }


    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public void QuitGame()

    {
        Application.Quit();
    }


}
