using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This Script Collects Data From The Player Such As Player Name, Game Difficulty, And Character Customisation
public class PlayerStats : MonoBehaviour
{
    //Variables That Store And Collect Name Input
    public string name;
    public bool hasInputedName;
    public InputField nameInput;
    public Text nameText;

    //Variables That Store And Collect Game Difficulty Input
    public int difficulty;
    public bool hasInputedDifficulty;
    public InputField difficultyInput;
    public Text difficultyText;

    //Variables That Change The Players Damage, Health And Defence
    public int attack;
    public int health;
    public int speed;

    public Text attackText;
    public Text healthText;
    public Text speedText;

    //Initialises Game Based On If They Have Played Or Not
    public InputField hasPlayedInput;
    public bool hasPlayed;
    public string[] acceptedHasPlayedStringsTrue;
    public string[] acceptedHasPlayedStringsFalse;

    //Game Manager Variables
    public DataManager manager;

    //Collects Game Manager Object using "Manager" tag
    private void Start() {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<DataManager>();
    }

    //In The Update Function I Will Collect Variables Data
    private void Update() {
        if(hasInputedName == false) { 
            if(nameInput.text != null && Input.GetKeyDown(KeyCode.Return)) {
                name = nameInput.text;
                nameText.text = nameInput.text;
                hasInputedName = true;
            }
        }

        if(hasInputedDifficulty == false) {
            if(difficultyInput.text != null && Input.GetKeyDown(KeyCode.Return)) {
                if(int.TryParse(difficultyInput.text, out difficulty)) {
                    difficulty = int.Parse(difficultyInput.text);
                    difficulty = Mathf.Clamp(difficulty, 1, 10);
                    difficultyInput.text = difficulty.ToString();
                    difficultyText.text = difficulty.ToString();
                    hasInputedDifficulty = true;
                }else {
                    difficultyInput.text = "Please Input A Number";
                    hasInputedDifficulty = false;
                }
            }
        }

        if(hasInputedDifficulty == true && hasInputedName == true) {
            hasPlayedInput.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Return)) {
                bool hasAccepted = false;
                for (int i = 0; i < acceptedHasPlayedStringsTrue.Length; i++) {
                    if(hasPlayedInput.text == acceptedHasPlayedStringsTrue[i]) {
                        hasPlayed = true;
                        hasAccepted = true;
                        StartGameWithoutTutorial();
                        return;
                    }
                    if(hasPlayedInput.text == acceptedHasPlayedStringsFalse[i]) {
                        hasPlayed = false;
                        hasAccepted = true;
                        StartTutorial();
                        return;
                    }
                }

                for (int i = 0; i < acceptedHasPlayedStringsFalse.Length; i++) {
                    if(hasPlayedInput.text == acceptedHasPlayedStringsFalse[i] && hasPlayed == true) {
                        hasPlayed = false;
                        hasAccepted = true;
                        StartTutorial();
                        return;
                    }
                }

                if(hasAccepted != true) {
                    hasPlayedInput.text = "Please Input An Accepted Value";
                }


            }
        }else {
            hasPlayedInput.gameObject.SetActive(false);
        }
    }

    //Button Changes Attack Variable
    public void ChangeAttack(int change) {
        attack += change;
        attackText.text = attack.ToString();
    }

    //Button Changes Health Variable
    public void ChangeHealth(int change) {
        health += change;
        healthText.text = health.ToString();
    }

    //Button Changes Defence Varibale
    public void ChangeSpeed(int change) {
        speed += change;
        speedText.text = speed.ToString();
    }

    //Starts Game Without Tutorial
    public void StartGameWithoutTutorial() {
        manager.playerName = name;
        manager.difficulty = difficulty;

        manager.attack = attack;
        manager.health = health;
        manager.speed = speed;
    }

    //Starts Game With Tutorial
    public void StartTutorial() {
        manager.playerName = name;
        manager.difficulty = difficulty;

        manager.attack = attack;
        manager.health = health;
        manager.speed = speed;
    }
}
