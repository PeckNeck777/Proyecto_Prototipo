using UnityEngine;

public class PickupGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int numInformes = 0;
    [SerializeField] private int informesNes = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void StartGame()
    {
        base.StartGame();
    }

   public void RecogerReportes()
    {
        numInformes++;
    }

    public void EntregarInformes()
    {
        if (numInformes == informesNes)
        {
            JuegoCompletado(true);
        }
    }
}
