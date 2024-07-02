using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Metoda do startu gry
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    // Metoda do wyjœcia z gry
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Dzia³a tylko w zbudowanej grze, nie w edytorze
    }
}
