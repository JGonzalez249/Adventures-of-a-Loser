using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Mountain : MonoBehaviour {


    private void Start()
    {
        PlayerPrefs.GetInt("Coins");

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(4);  
    }


}
