using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int DIAMENTY;
    public int maxDiamenty = 30; // Maksymalna liczba diament�w do zebrania

    public GameObject messagePanel; // Przeci�gnij tutaj panel z wiadomo�ci�
    public Text messageText; // Przeci�gnij tutaj Text z wiadomo�ci�
    public string completeMessage = "Wszystkie diamenty zebrane!"; // Wiadomo�� do wy�wietlenia
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
        HideMessage(); // Na pocz�tku ukryj wiadomo��
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

        // Resetowanie wyniku diament�w przy ka�dym prze�adowaniu sceny (np. powr�t do menu)
        if (scene.name == "New_menu")
        {
            ResetScore();
        }

        HideMessage(); // Zresetuj wiadomo�� przy przej�ciu do nowej sceny
    }

    public void AddScore(int amount)
    {
        DIAMENTY += amount;
        UpdateScoreText();

        // Sprawd�, czy wszystkie diamenty zosta�y zebrane
        if (DIAMENTY >= maxDiamenty)
        {
            DisplayAllDiamondsCollectedMessage();
            interactionManager.ShowCompletionMessage();

            // Po zebraniu wszystkich diament�w, przejd� do nowej sceny (np. "WinScene")
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

            // Po zebraniu wszystkich diament�w, przejd� do nowej sceny (np. "WinScene")
            SceneManager.LoadScene("end");
        }
    }

    void DisplayAllDiamondsCollectedMessage()
    {
        // Wy�wietl wiadomo��, je�li panel wiadomo�ci jest przypisany
        if (messagePanel != null && messageText != null)
        {
            messageText.text = completeMessage;
            messagePanel.SetActive(true);
        }
    }

    void HideMessage()
    {
        // Ukryj wiadomo��, je�li panel wiadomo�ci jest przypisany
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }

    void ResetScore()
    {
        DIAMENTY = 0; // Zresetuj wynik diament�w
        UpdateScoreText(); // Zaktualizuj tekst wyniku
    }

    public void PlayDeathSound()
    {
        AudioManager.instance.Play("DeathSound"); // Odtw�rz d�wi�k przez AudioManager
    }
}
