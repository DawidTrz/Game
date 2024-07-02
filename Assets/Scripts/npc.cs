using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private InteractionManager interactionManager; // Referencja do InteractionManager

    void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>(); // ZnajdŸ InteractionManager w scenie
        if (interactionManager == null)
        {
            Debug.LogError("InteractionManager not found in the scene!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Wywo³aj metodê z InteractionManager, aby pokazaæ tekst przed zdobyciem diamentów
            if (!interactionManager.diamondsCollected)
            {
                interactionManager.InteractWithNPCBeforeCompletion();
            }
            else
            {
                // Wywo³aj metodê z InteractionManager, aby pokazaæ tekst po zdobyciu diamentów
                interactionManager.ShowCompletionMessage();
            }
        }
    }
}
