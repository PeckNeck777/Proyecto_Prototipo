using UnityEngine;

public class PickUpScreen : MonoBehaviour
{
    [SerializeField] PickupGame game;
    [SerializeField] GameObject panel;
    
    public void BotonEntregar()
    {
        game.EntregarInformes();
        panel.SetActive(false);
    }
}
