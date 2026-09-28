using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Minigame mini;

    /*
     * Se encarga de que los minijuegos de la escena funcionen bien sin problema alguno
     */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(mini != null)
        {
            mini.StartGame();
        }
        else
        {
            Debug.Log("No hay minijuego!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
