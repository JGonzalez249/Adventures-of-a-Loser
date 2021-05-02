using UnityEngine;
using UnityEngine.UI;

public class Guard1Dialog : MonoBehaviour
{
    [SerializeField] GameObject DialogBox;

    public Text npcTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);

            npcTextUI.text = "Just ahead is the forest, plenty of opportunity there, can't wait to leave behind the rabble in this forsaken village when our glorious mayor wins his re-election!";

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
