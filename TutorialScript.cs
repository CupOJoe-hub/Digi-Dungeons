using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public Transform player;

    public bool collectedPositiveX;
    public bool collectedNegetiveX;
    public bool collectedSprint;
    public bool collectedAttack;

    public Text tutorialText;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() { 
        tutorialText.text = "You Can Use A+D to Move And Z+X To Sprint";

        if(Input.GetKeyDown(KeyCode.D)) {
            collectedPositiveX = true;
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            collectedNegetiveX = true;
        }
        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)) {
            collectedSprint = true;
        }

        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true) {
            tutorialText.text = "Press E To Attack"; 
            if(Input.GetKeyDown(KeyCode.E)) {
                collectedAttack = true;
            }
        }

        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true && collectedAttack == true) {
            tutorialText.text = "Exit The Tutorial To The Right";
            if(player.position.x >= 10) {
                Finished();
            }
        }
    }

    void Finished() {
        SceneManager.LoadScene("Game");
    }
}
