using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private void Awake()
    {
        isGameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        Debug.Log("Back to main menu working!");
        AudioManager.instance.Play("click");
        SceneManager.LoadScene("New_menu");
    }
}
