using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    //Varibales Needed To Keep Player Data
    public string playerName = "Default";
    public int difficulty = 3;
    public int attack = 3;
    public int speed = 3;
    public int health = 3;

    //UI
    public Text nameText;
    public Slider healthSlider;

    public Text difficultyText;
    public Text attackText;
    public Text speedText;
    public Text healthText;

    public DataManager data;

    private void Update() {
        if(GameObject.FindGameObjectWithTag("DataManager") != null) {
            data = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();    
            Debug.Log(data.gameObject.name);
            playerName = data.playerName;
            difficulty = data.difficulty;
            attack = data.attack;
            speed = data.speed;
            health = data.health;
        }
        if(nameText != null) {
            nameText.text = playerName;
        }
        if(difficultyText != null) {
            difficultyText.text = difficulty.ToString();
        }
        if(attackText != null){ 
            attackText.text = attack.ToString();
        }
        if(speedText != null){ 
            speedText.text = speed.ToString();
        }
        if(healthText != null){ 
            healthText.text = health.ToString();
        }
    }
}
