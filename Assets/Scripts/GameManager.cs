using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int DIAMENTY;
    public int maxDiamenty = 30; // Maksymalna liczba diamentów do zebrania

    public GameObject messagePanel; // Przeci¹gnij tutaj panel z wiadomoœci¹
    public Text messageText; // Przeci¹gnij tutaj Text z wiadomoœci¹
    public string completeMessage = "Wszystkie diamenty zebrane!"; // Wiadomoœæ do wyœwietlenia
    public InteractionManager interactionManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateScoreText();
        HideMessage(); // Na pocz¹tku ukryj wiadomoœæ
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.FindWithTag("ScoreText")?.GetComponent<Text>();
        UpdateScoreText();
        Time.timeScale = 1f;

        // Resetowanie wyniku diamentów przy ka¿dym prze³adowaniu sceny (np. powrót do menu)
        if (scene.name == "New_menu")
        {
            ResetScore();
        }

        HideMessage(); // Zresetuj wiadomoœæ przy przejœciu do nowej sceny
    }

    public void AddScore(int amount)
    {
        DIAMENTY += amount;
        UpdateScoreText();

        // SprawdŸ, czy wszystkie diamenty zosta³y zebrane
        if (DIAMENTY >= maxDiamenty)
        {
            DisplayAllDiamondsCollectedMessage();
            interactionManager.ShowCompletionMessage();

            // Po zebraniu wszystkich diamentów, przejdŸ do nowej sceny (np. "WinScene")
            SceneManager.LoadScene("end");
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "DIAMENTY: " + DIAMENTY + "/" + maxDiamenty;
        }
        if (DIAMENTY >= maxDiamenty)
        {
            DisplayAllDiamondsCollectedMessage();
            interactionManager.ShowCompletionMessage();

            // Po zebraniu wszystkich diamentów, przejdŸ do nowej sceny (np. "WinScene")
            SceneManager.LoadScene("end");
        }
    }

    void DisplayAllDiamondsCollectedMessage()
    {
        // Wyœwietl wiadomoœæ, jeœli panel wiadomoœci jest przypisany
        if (messagePanel != null && messageText != null)
        {
            messageText.text = completeMessage;
            messagePanel.SetActive(true);
        }
    }

    void HideMessage()
    {
        // Ukryj wiadomoœæ, jeœli panel wiadomoœci jest przypisany
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }

    void ResetScore()
    {
        DIAMENTY = 0; // Zresetuj wynik diamentów
        UpdateScoreText(); // Zaktualizuj tekst wyniku
    }

    public void PlayDeathSound()
    {
        AudioManager.instance.Play("DeathSound"); // Odtwórz dŸwiêk przez AudioManager
    }
}
