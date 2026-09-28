using UnityEngine;


/*
 * Reportes fisicos dentro del juego, el jugador se acerca y se recogen
 * Aumenta el contador de reportes recogidos
 */
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
