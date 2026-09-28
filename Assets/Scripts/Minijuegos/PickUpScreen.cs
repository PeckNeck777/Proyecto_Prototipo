using UnityEngine;

/*
 * Se activa la pantalla para entregar los reportes
 * Se presiona el boton y se entregan los reportes
 */
public class PickUpScreen : MonoBehaviour
{
    [SerializeField] PickupGame game;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject cam;

    public void BotonEntregar()
    {
        game.EntregarInformes();
        panel.SetActive(false);
        cam.SetActive(false);
    }

    public void BotonDesentregar()
    {

        panel.SetActive(false);
        cam.SetActive(false);
    }
}
