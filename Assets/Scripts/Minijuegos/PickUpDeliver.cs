using UnityEngine;

public class PickUpDeliver : MonoBehaviour
{
    [SerializeField] PickupGame game;

    [SerializeField] private int numCaso;


    private void OnTriggerEnter(Collider other)
    {
        game.RecogerReportes();
        gameObject.SetActive(false);
    }
}
