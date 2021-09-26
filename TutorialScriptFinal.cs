using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//This Script Handles The Instructions Given To The Player During The Tutorial
public class TutorialScript : MonoBehaviour
{
    public Transform player;

    public bool collectedPositiveX;
    public bool collectedNegetiveX;
    public bool collectedSprint;
    public bool collectedAttack;
    public bool collectedOptions;
    public bool collectedInventory;

    public Text tutorialText;

    //Gathers And Sets Initialisation Variables
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        tutorialText.text = "You Can Use A+D to Move And Z+X To Sprint";
    }

    //Collects Input For Tutorial From Player And Sets Booleans When Player Completes Tasks
    private void Update() { 
        //Checks If Player Has Used The Move Right Key
        if(Input.GetKeyDown(KeyCode.D)) {
            collectedPositiveX = true;
        }
        //Checks If Player Has Used The Move Left Key
        if(Input.GetKeyDown(KeyCode.A)) {
            collectedNegetiveX = true;
        }
        //Checks If Player Has Used Either Sprint Key Key
        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)) {
            collectedSprint = true;
        }

        //Checks If Player Has Used The Attack Key
        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true) {
            tutorialText.text = "Press E To Attack"; 
            if(Input.GetKeyDown(KeyCode.E)) {
                collectedAttack = true;
            }
        }

        //Checks If Player Uses The Options Key
        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true && collectedAttack == true) {
            tutorialText.text = "Press Escape (Esc) To Enter The Menu";
            if(Input.GetKeyDown(KeyCode.Escape)){ 
                collectedOptions = true;
            }
        }

        //Checks If Player Uses The Inventory Key
        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true && collectedAttack == true && collectedOptions == true) {
            tutorialText.text = "Press Tab To Enter The Inventory";
            if(Input.GetKeyDown(KeyCode.Tab)) {
                collectedInventory = true;
            }
        }

        //Checks If The Player Is To The Right Of The Screen
        if(collectedSprint == true && collectedPositiveX == true && collectedNegetiveX == true && collectedAttack == true && collectedOptions == true && collectedInventory == true) {
            tutorialText.text = "Exit The Tutorial To The Right";
            if(player.position.x >= 10) {
                Finished();
            }
        }
    }

    //Loads Game Scene Once Method Is Called
    void Finished() {
        SceneManager.LoadScene("Game");
    }
}
