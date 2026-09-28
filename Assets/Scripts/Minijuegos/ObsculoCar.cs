using UnityEngine;

/*
 * Obstaculos del minijuego del carro
 */
public class ObsculoCar : MonoBehaviour
{
    [SerializeField] DrivingGame game;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            game.ObstaculoHit();
            Destroy(collision.gameObject);  
        }
    }
}
