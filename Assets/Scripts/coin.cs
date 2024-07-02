using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Zak³adamy, ¿e gracz ma tag "Player"
        {
            GameManager.instance.AddScore(1); // Zak³adamy, ¿e GameManager zarz¹dza punktami
            AudioManager.instance.Play("Coins");
            Destroy(gameObject); // Zniszcz monetê po zebraniu
        }
    }
}
