using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public void OnStartClick() {
        SceneManager.LoadScene("DreamArena_Test");
    }

    public void OnExitClick() {
        Application.Quit();
    }

    public void OnStoryClick() {
        //SceneManager.LoadScene("MainStory");
    }
}
