using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodcutterDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "Damn that mayor! Making me work without stop, cutting down that forest day and night. I don't know why he has me working like a dog but I'm not getting the pay in need for my family. \n Lad, if you can spare some coin, I can quit and look for better employ.";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(false);

        }
    }
}
