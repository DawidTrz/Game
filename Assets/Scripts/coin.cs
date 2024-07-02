using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Zak�adamy, �e gracz ma tag "Player"
        {
            GameManager.instance.AddScore(1); // Zak�adamy, �e GameManager zarz�dza punktami
            AudioManager.instance.Play("Coins");
            Destroy(gameObject); // Zniszcz monet� po zebraniu
        }
    }
}
