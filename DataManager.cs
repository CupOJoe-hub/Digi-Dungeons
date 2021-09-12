using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string playerName;
    public int difficulty;
    public int attack;
    public int speed;
    public int health;

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }
}
