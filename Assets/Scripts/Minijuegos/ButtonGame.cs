using TMPro;
using UnityEngine;

/*
 * Encargado del minijuego de presionar los botones en orden
 * Si se presionan bien de acuerdo a su ID
 * Se ponen verdes y si se llegan a presionar todos se completa
 * De presionar el boton incorrecto, se reinicia el progreso y 
 * todos vuelven a su color original
 */
public class ButtonGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int numID;
    [SerializeField] private int totalID;

    [SerializeField] private GameObject[] todosLosBotones;
    [SerializeField] private TMP_Text textoMini;

    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;
        numID = 1;

        ResetearBotones();
        textoMini.text = "Presiona los botones con click en orden!";
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
            JuegoCompletadoTrabajo(true);
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
