using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Menu Manager Holds Data For Showing Panels, Quitting And Resuming The Level, Ans Quitting The Game
public class MenuHandler : MonoBehaviour
{
    public GameObject optionsPanel;
    public bool isOpen;

    //Initialisation Sets Objects And Booleans To False To Prevent Clashing When Loading The Level
    private void Start() {
        optionsPanel.SetActive(false);
        isOpen = false;
    }

    //Holds Input For When The Player Opens The Options Menu
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && optionsPanel != null) {
            isOpen = !isOpen;
            optionsPanel.SetActive(isOpen);
            if(optionsPanel.activeSelf == true) {
                Time.timeScale = 0f;
            }else {
                Time.timeScale = 1f;
            }
        }
    }

    //Resumes Game And Unfreezes It From The Options Menu
    public void Resume() {
        optionsPanel.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
    }

    //Quits Level Back To The Main Menu 
    public void Exit() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //Quits Entire Game
    public void QuitGame() {
        Application.Quit();
    }
}
