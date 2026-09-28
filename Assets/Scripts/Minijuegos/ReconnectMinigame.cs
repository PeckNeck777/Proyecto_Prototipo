using TMPro;
using UnityEngine;


/*
 * Para reconectar los routers, si se reconectan 2 se gana el mini juego
 */
public class ReconnectMinigame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private float progreso;
    [SerializeField] private int routersReconectados = 0;
    [SerializeField] private TMP_Text textoMini;
    public override void StartGame()
    {
        base.StartGame();
        progreso = 0f;
        textoMini.text = "Mueve el router un tiempo cercano al punto de señal, el color debe indicarte bien donde anda, dejalo un rato ahi y mantenlo el movimiento!";
    }

    public float AumentarProgreso(float progre)
    {
        progreso += progre;
        return progreso;
    }

    public void Finiquitar()
    {
        if (!juegoActi) return;

        Debug.Log("Finiquitado el router");
        routersReconectados++;
        progreso = 0;

        if(routersReconectados >= 2)
        {
            JuegoCompletadoTrabajo(true);
        }
    }
}
