using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNPC : MonoBehaviour
{

    [SerializeField] GameObject DialogBox;
    [SerializeField] GameObject GoToMayor;
    [SerializeField] GameObject ContinueMessage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(true);
            ContinueMessage.SetActive(true);
            GoToMayor.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogBox.SetActive(false);
            ContinueMessage.SetActive(false);
            GoToMayor.SetActive(true);
        }
    }
}
