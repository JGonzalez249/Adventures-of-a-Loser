using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WomanDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "Hello good sir, I'm running for mayor, the people of this community, I felt, needed a new voice in order to solve the problems we currently have. \n" +
                "I don't need funds, however, I feel that you can help the people of this village, that's all I ask of you kind Adventurer.";

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
