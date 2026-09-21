using UnityEngine;

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
