using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Diespace")
        {
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
    }
}
