using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldManDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;

    private int coins;

    private void Start()
    {
        GameController.instance.CountCoins(coins);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "Welcome to my stand lad, do you have coin....no? \n Then off with you worthless lower class trash!";

            if (coins >= 300)
            {
                npcTextUI.text = "Well, well. I see you have the coin to actually be something more than trash, well come boy! Look at my wares that not even a tenth of the vilage are allowed to see";
            }

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
