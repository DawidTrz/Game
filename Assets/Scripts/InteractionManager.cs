using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public GameObject beforeCompletionObject; // Obiekt do wyœwietlenia przed zdobyciem wszystkich diamentów
    public GameObject afterCompletionObject; // Obiekt do wyœwietlenia po zdobyciu wszystkich diamentów
    public bool diamondsCollected = false; // Flaga mówi¹ca, czy wszystkie diamenty zosta³y zebrane

    void Start()
    {
        if (beforeCompletionObject != null)
        {
            beforeCompletionObject.SetActive(true); // Poka¿ obiekt przed zdobyciem diamentów
        }
        if (afterCompletionObject != null)
        {
            afterCompletionObject.SetActive(false); // Ukryj obiekt po zdobyciu diamentów na pocz¹tku
        }
    }

    void Update()
    {
        // Obs³uga interakcji klawiszowej tylko przed zdobyciem diamentów
        if (!diamondsCollected && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNPCBeforeCompletion();
        }

        // Obs³uga ukrywania tekstu za pomoc¹ strza³ki
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
            beforeCompletionObject.SetActive(false); // Ukryj obiekt przed zdobyciem diamentów
        }
        if (afterCompletionObject != null)
        {
            afterCompletionObject.SetActive(true); // Poka¿ obiekt po zdobyciu diamentów
        }
    }

    public void InteractWithNPCBeforeCompletion()
    {
        // Kod do wyœwietlenia tekstu przed zdobyciem diamentów
        Debug.Log("Meow you haven't found all the diamonds yet. Come back when you find them, meow.");
    }

    void HideMessage()
    {
        // Ukryj wiadomoœæ po zdobyciu diamentów, jeœli jest wyœwietlana
        if (diamondsCollected && afterCompletionObject != null && afterCompletionObject.activeSelf)
        {
            afterCompletionObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit(); // Wyjœcie z gry (dzia³a tylko w buildach)
    }
}
