using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Routers a reconectar, su progreso aumenta al estar cerca del punto especifico
 * Cuando esta justo en el punto, se reconecta mas rapido
 * De lo contrario se reconecta normal
 * Si no esta cerca del punto, no aumenta nada
 */
public class ReconnectArea : DragObjects
{
    [SerializeField] private float progreso;
    [SerializeField] private Transform puntoCercano;
    [SerializeField] private float minDis = 1f;
    [SerializeField] private float maxDis = 3f;
    [SerializeField] public ReconnectMinigame juegoRouter;
    [SerializeField] TMP_Text textoProgre;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        MoverRouter();
    }

    public override void OnMouseDrag()
    {
        base.OnMouseDrag();
        MoverRouter();
    }

    public void MoverRouter()
    {
        float distancia = Vector2.Distance(transform.position, puntoCercano.position);
        textoProgre.text = "Señal recuperada " + Mathf.RoundToInt(progreso) + "%";

    
        if (distancia <= minDis)
        {
            progreso = juegoRouter.AumentarProgreso(15f * Time.deltaTime); 
        }
        else if (distancia <= maxDis)
        {
            progreso = juegoRouter.AumentarProgreso(5f * Time.deltaTime);
        }

        if (progreso >= 100)
        {
            juegoRouter.Finiquitar();
            gameObject.SetActive(false);
        }
    }
}
