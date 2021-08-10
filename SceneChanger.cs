using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private void Start() {
        //Dosen't Destroy GameObject When Loading Into Different Scenes
        DontDestroyOnLoad(gameObject);
    }

    //Change Current Scene To Game
    public void ChangeToGameScene() {

    }

    //Change Current Scene Back To Main Menu
    public void ChangeToMenuScreen() {

    }
}
