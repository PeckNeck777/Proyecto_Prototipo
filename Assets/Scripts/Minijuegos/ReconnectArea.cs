using Unity.VisualScripting;
using UnityEngine;

public class ReconnectArea : DragObjects
{
    [SerializeField] private float progreso;
    [SerializeField] private Transform puntoCercano;
    [SerializeField] private float minDis = 1f;
    [SerializeField] private float maxDis = 3f;
    [SerializeField] public ReconnectMinigame juegoRouter;

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
