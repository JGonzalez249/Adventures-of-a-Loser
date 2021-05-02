using UnityEngine;
using UnityEngine.UI;

public class ManDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "Hello adventurer, if you need a place to stay, I'm open to you...however, if you don't have the coin. \n Then you are not worth anything, unfortunately many in this village aren't anything either.";

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

