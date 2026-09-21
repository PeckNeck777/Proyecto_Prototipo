using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Minigame mini;

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
