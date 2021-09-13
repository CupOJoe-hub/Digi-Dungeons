using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //Varibales Needed To Keep Player Data
    public string playerName = "Default";
    public int difficulty = 3;
    public int attack = 3;
    public int speed = 3;
    public int health = 3;

    private void Start() {
        if(GameObject.FindGameObjectWithTag("Manager") != null) {
            DataManager data = GameObject.FindGameObjectWithTag("Manager").GetComponent<DataManager>();    
            playerName = data.playerName;
            difficulty = data.difficulty;
            attack = data.attack;
            speed = data.speed;
            health = data.health;
        }
    }
}
