using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject optionsPanel;
    public bool isOpen;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isOpen = !isOpen;
            optionsPanel.SetActive(isOpen);
            if(optionsPanel.activeSelf == true) {
                Time.timeScale = 0f;
            }else {
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume() {
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit() {
        SceneManager.LoadScene("Menu");
    }
}
