using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This Script Handles the health, defence, stamina and general statistics of the player
public class PlayerStats : MonoBehaviour
{
    //These variables are the stats of the player
    [Header("Stats")]
    public float maxHealth;
    private float currentHealth;
    public Image healthBar;

    public int defence;
    public int stamina;
    public int attack;

    public int maxStats;
    public int statsStart;
    public int statsLeft;

    public Text defenceText;
    public Text staminaText;
    public Text attackText;

    public int coins;

    public int difficulty;
    public int maxDifficulty;
    public bool hasDifficultyInput;

    //Control variables
    [Header("Control Variables")]
    public float healthRegen;
    public float healthRegenWaitTime;

    //UI & Input
    [Header("UI & Input")]
    public InputField input;
    public string name;
    private bool isOpen;
    private bool hasInput;
    public InputField difficultyInput;

    private void Start() {
        input.gameObject.SetActive(true);

        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(input.text != null) {
            hasInput = true;
        }else {
            Debug.Log("Input Text");
        }

        if(difficultyInput.text != null) {
            hasDifficultyInput = true;
        }else {
            Debug.Log("Input Text");
        }

        //checks if there is text in the input box and that the enter key has been pressed
        if(hasInput && Input.GetKeyDown(KeyCode.Return)) {
            name = input.text;
        }

        if(hasDifficultyInput && Input.GetKeyDown(KeyCode.Return)) {
            if(Int32.TryParse(difficultyInput.text, out difficulty) == true) {
                difficulty = Int32.Parse(difficultyInput.text);
                if(difficulty > maxDifficulty) {
                    difficulty = maxDifficulty;
                    difficultyInput.text = difficulty.ToString();
                }
            }else {
                difficultyInput.text = "Please Input A Valid Number";
            }
        }

        if(currentHealth <= 0) {
            //Triggers when player dies from less than or 0 currentHealth
            Die();
        }
    }

    private void Die() {
        //Triggers when player dies from less than or 0 currentHealth
    }

    public void AddAttack(int amount) {
        if(statsLeft > 0) {
            if(amount < 0 && statsLeft > 0){ 

            }else {
                attack += amount;
                attack = Mathf.Clamp(attack, 0, maxStats);
                attackText.text = attack.ToString();
            }
        }
    }
    public void AddStamina(int amount) {
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, maxStats);
        staminaText.text = stamina.ToString();
    }
    public void AddDefence(int amount) {
        defence += amount;
        defence = Mathf.Clamp(defence, 0, maxStats);
        defenceText.text = defence.ToString();
    }

}
