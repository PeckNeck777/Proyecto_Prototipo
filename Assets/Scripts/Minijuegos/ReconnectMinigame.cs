using UnityEngine;

public class ReconnectMinigame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private float progreso;
    [SerializeField] private int routersReconectados = 0;
    public override void StartGame()
    {
        base.StartGame();
        progreso = 0f;
        routersReconectados = 0;
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
            JuegoCompletado(true);
        }
    }
}
