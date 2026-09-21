using UnityEngine;

public class DragAro : DragObjects
{
    [SerializeField] private AroGame game;

    private bool procesado = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnEnable()
    {
        procesado = false; 
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    public override void OnMouseDrag()
    {
        base.OnMouseDrag();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (procesado) return;

        if (collision.gameObject.CompareTag("Obstucalo")) 
        {
            procesado = true;
            
            game.EscenarioPerdido();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (procesado) return;

        if (other.gameObject.CompareTag("Ganar"))
        {
            procesado = true;
            game.EscenariosExitosos();
        }
    }
}
