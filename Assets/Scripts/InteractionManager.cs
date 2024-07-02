using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public GameObject beforeCompletionObject; // Obiekt do wy�wietlenia przed zdobyciem wszystkich diament�w
    public GameObject afterCompletionObject; // Obiekt do wy�wietlenia po zdobyciu wszystkich diament�w
    public bool diamondsCollected = false; // Flaga m�wi�ca, czy wszystkie diamenty zosta�y zebrane

    void Start()
    {
        if (beforeCompletionObject != null)
        {
            beforeCompletionObject.SetActive(true); // Poka� obiekt przed zdobyciem diament�w
        }
        if (afterCompletionObject != null)
        {
            afterCompletionObject.SetActive(false); // Ukryj obiekt po zdobyciu diament�w na pocz�tku
        }
    }

    void Update()
    {
        // Obs�uga interakcji klawiszowej tylko przed zdobyciem diament�w
        if (!diamondsCollected && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNPCBeforeCompletion();
        }

        // Obs�uga ukrywania tekstu za pomoc� strza�ki
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HideMessage();
        }
    }

    public void ShowCompletionMessage()
    {
        diamondsCollected = true;
        if (beforeCompletionObject != null)
        {
            beforeCompletionObject.SetActive(false); // Ukryj obiekt przed zdobyciem diament�w
        }
        if (afterCompletionObject != null)
        {
            afterCompletionObject.SetActive(true); // Poka� obiekt po zdobyciu diament�w
        }
    }

    public void InteractWithNPCBeforeCompletion()
    {
        // Kod do wy�wietlenia tekstu przed zdobyciem diament�w
        Debug.Log("Meow you haven't found all the diamonds yet. Come back when you find them, meow.");
    }

    void HideMessage()
    {
        // Ukryj wiadomo�� po zdobyciu diament�w, je�li jest wy�wietlana
        if (diamondsCollected && afterCompletionObject != null && afterCompletionObject.activeSelf)
        {
            afterCompletionObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit(); // Wyj�cie z gry (dzia�a tylko w buildach)
    }
}
