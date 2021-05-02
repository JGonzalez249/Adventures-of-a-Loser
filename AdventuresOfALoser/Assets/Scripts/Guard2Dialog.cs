using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guard2Dialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "To the east of here is the mountains, would love to have a nice quiet place there. At least to get away from the...maybe I shouldn't say this while the current mayor is in charge.";

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
