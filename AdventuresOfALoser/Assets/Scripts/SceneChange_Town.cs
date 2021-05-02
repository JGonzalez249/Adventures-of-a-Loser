using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange_Town : MonoBehaviour {


    private void Start()
    {

        PlayerPrefs.GetInt("Coins");

       // GameController.instance.DecreaseHealth(health);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);
        
    }


}
