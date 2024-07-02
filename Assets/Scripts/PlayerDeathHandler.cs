using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    public Transform playerTransform; // Przeci¹gnij gracza tutaj
    public float deathYPosition = -10f; // Wysokoœæ, przy której gracz ginie
    public GameObject deathPanel; // Przeci¹gnij tutaj `Panel` z UI

    void Start()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false); // Ukryj panel na pocz¹tku gry
        }
    }

    void Update()
    {
        if (playerTransform.position.y < deathYPosition)
        {
            TriggerDeath();
        }
    }

    void TriggerDeath()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0f; // Zamro¿enie gry
            GameManager.instance.PlayDeathSound();
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Odmro¿enie gry
        SceneManager.LoadScene("New_menu"); // Za³aduj scenê Menu
    }
}
