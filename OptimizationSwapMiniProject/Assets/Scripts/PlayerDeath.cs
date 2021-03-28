using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            Destroy(gameObject);
            GameController.instance.Respawn();
            GameController.instance.DecreaseHealth(dmg);
        }
    }
}
