using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        AudioManager.instance.Play("teleport");
        return destination;
    }
}