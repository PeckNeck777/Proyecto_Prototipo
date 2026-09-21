using UnityEngine;

public class ButtonGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int numID;
    [SerializeField] private int totalID;

    [SerializeField] private GameObject[] todosLosBotones;

    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;
        numID = 1;

        ResetearBotones();
    }


    public void PresionarBotonCorrecto(int indice, GameObject buton)
    {
        if(numID == indice)
        {
            numID++;
            buton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            numID = 1;
            ResetearBotones();
        }

        if(numID >= totalID)
        {
            JuegoCompletado(true);
            foreach (GameObject btn in todosLosBotones)
            {
                if (btn != null)
                {
                    btn.SetActive(false);

                }
            }
        }
    }

    public void ResetearBotones()
    {
        if (todosLosBotones == null) return;

        foreach(GameObject btn in todosLosBotones)
        {
            if(btn != null)
            {
                btn.GetComponent<SpriteRenderer>().color = Color.white;

            }
        }
    }
}
