using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    public Transform playerTransform; // Przeci�gnij gracza tutaj
    public float deathYPosition = -10f; // Wysoko��, przy kt�rej gracz ginie
    public GameObject deathPanel; // Przeci�gnij tutaj `Panel` z UI

    void Start()
    {
        if (deathPanel != null)
        {
            deathPanel.SetActive(false); // Ukryj panel na pocz�tku gry
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
            Time.timeScale = 0f; // Zamro�enie gry
            GameManager.instance.PlayDeathSound();
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Odmro�enie gry
        SceneManager.LoadScene("New_menu"); // Za�aduj scen� Menu
    }
}
