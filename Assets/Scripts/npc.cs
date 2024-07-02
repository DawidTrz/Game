using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private InteractionManager interactionManager; // Referencja do InteractionManager

    void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>(); // Znajd� InteractionManager w scenie
        if (interactionManager == null)
        {
            Debug.LogError("InteractionManager not found in the scene!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Wywo�aj metod� z InteractionManager, aby pokaza� tekst przed zdobyciem diament�w
            if (!interactionManager.diamondsCollected)
            {
                interactionManager.InteractWithNPCBeforeCompletion();
            }
            else
            {
                // Wywo�aj metod� z InteractionManager, aby pokaza� tekst po zdobyciu diament�w
                interactionManager.ShowCompletionMessage();
            }
        }
    }
}
