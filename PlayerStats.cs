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

    //Variables That Store And Collect Game Difficulty Input
    public int difficulty;
    public bool hasInputedDifficulty;
    public InputField difficultyInput;

    //Variables That Change The Players Damage, Health And Defence
    public int attack;
    public int health;
    public int defence;

    //Initialises Game Based On If They Have Played Or Not
    public InputField hasPlayedInput;
    public bool hasPlayed;
    public string[] acceptedHasPlayedStringsTrue;
    public string[] acceptedHasPlayedStringsFalse;

    public string[] wierdInputStrings;

    //In The Update Function I Will Collect Variables Data
    private void Update() {
        if(hasInputedName == false) { 
            if(nameInput.text != null && Input.GetKeyDown(KeyCode.Return)) {
                name = nameInput.text;
                hasInputedName = true;
            }
        }

        if(hasInputedDifficulty == false) {
            if(difficultyInput.text != null && Input.GetKeyDown(KeyCode.Return)) {
                if(int.TryParse(difficultyInput.text, out difficulty)) {
                    difficulty = int.Parse(difficultyInput.text);
                    difficulty = Mathf.Clamp(difficulty, 1, 10);
                }else {
                    difficultyInput.text = "Please Input A Number";
                }
            }
        }

        if(hasInputedDifficulty == true && hasInputedName == true) {
            hasPlayedInput.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Return)) {
                for (int i = 0; i < acceptedHasPlayedStringsTrue.Length; i++) {
                    if(hasPlayedInput.text == acceptedHasPlayedStringsTrue[i]) {
                        hasPlayed = true;
                        StartGameWithoutTutorial();
                    }
                }

                for (int i = 0; i < acceptedHasPlayedStringsFalse.Length; i++) {
                    if(hasPlayedInput.text == acceptedHasPlayedStringsFalse[i]) {
                        hasPlayed = false;
                        StartTutorial();
                    }
                }

                for (int i = 0; i < wierdInputStrings.Length; i++) {
                    if(hasPlayedInput.text == wierdInputStrings[i]) {
                        hasPlayed = false;
                        hasPlayedInput.text = hasPlayedInput + "?" + " Are You Stupid?";
                    }
                }
            }
        }else {
            hasPlayedInput.gameObject.SetActive(false);
        }
    }

    //Button Changes Attack Variable
    public void ChangeAttack(int change) {
        attack += change;
    }

    //Button Changes Health Variable
    public void ChangeHealth(int change) {
        health += change;
    }

    //Button Changes Defence Varibale
    public void ChangeDefence(int change) {
        defence += change;
    }

    //Starts Game Without Tutorial
    public void StartGameWithoutTutorial() {

    }

    //Starts Game With Tutorial
    public void StartTutorial() {

    }
}
