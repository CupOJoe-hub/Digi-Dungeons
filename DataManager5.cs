using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Holds Data For The Player And Transfers To Tutorial And Game Scenes
public class DataManager : MonoBehaviour
{
    //Bool Contain Wheather or Not The Current Level Is A Tutorial
    public bool isTutorial;

    //Varibales Needed To Keep Player Data
    public string playerName;
    public int difficulty;
    public int attack;
    public int speed;
    public int health;

    public bool hasSetMaxHealth;

    //Default Player Values
    public string defaultPlayerName = "Default";
    public int defaultDifficulty = 2;
    public int defaultAttack = 3;
    public int defaultSpeed = 3;
    public int defaultHealth = 3;

    //UI
    public Text nameText;
    public Slider healthSlider;

    //Makes Sure The GameObject Does Not Get Destroyed When Changes To The Next Scene
    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    //During The Update Function, It Changes Values Of Texts
    private void Update() {
        if(isTutorial == true) {
            if(nameText == null && GameObject.FindGameObjectWithTag("nameText") != null) {
                nameText = GameObject.FindGameObjectWithTag("nameText").GetComponent<Text>();
            }
            if(healthSlider == null && GameObject.FindGameObjectWithTag("healthSlider") != null) {
                healthSlider = GameObject.FindGameObjectWithTag("healthSlider").GetComponent<Slider>();
            }
            if(nameText != null) {
                nameText.text = defaultPlayerName;
            }
            if(healthSlider != null) {
                healthSlider.value = health;
            }
            if(hasSetMaxHealth == false && healthSlider != null) {
                healthSlider.maxValue = health;
                hasSetMaxHealth = true;
            }
        }else {
            if(nameText != null) {
                nameText.text = playerName;
            }
        }
        
    }
}
