using TMPro;
using UnityEngine;

/*
 * Juego del aro, se tiene un tiempo especifico para
 * completar el escenario
 * cuando se completa, se activa otro diferente y si se completan 3
 * se gana el minijuego
 * De equivocarse 3 veces en el juego (Que es chocar con los bordes)
 * O se acaba el tiempo y no se ha llegado al final, se pierde
 */
public class AroGame : Minigame
{
    [Header("Información")]
    [SerializeField] private float tiempoPorEscenario = 15f; 
    [SerializeField] private int escenariosCompletos;
    [SerializeField] private GameObject[] miniNiveles;
    [SerializeField] private TMP_Text textoTimer;
    [SerializeField] private TMP_Text textoIntentos;
    [SerializeField] private AudioClip wrongAnswer;
    [SerializeField] private AudioClip correctAnswer;
    [SerializeField] private AudioSource answer;

    private int indexEscen;

    public override void StartGame()
    {
        base.StartGame();

        intentosRestantes = 3;
        type = MinigameType.Intentos;
        escenariosCompletos = 0;
        indexEscen = 0;


        ActualizarTimer();
        ActivarPanel();
    }

    protected override void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (!juegoActi) return; 

        if (textoTimer != null)
        {
            textoTimer.text = "Tiempo restante para fallar: " + Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }

        textoIntentos.text = "Intentos restantes: " + intentosRestantes.ToString() + "/3";

        if (tiempoRestante <= 0)
        {
            EscenarioPerdido();
        }
    }

    public void EscenariosExitosos()
    {
        if (!juegoActi) return;

        escenariosCompletos++;

        answer.PlayOneShot(correctAnswer);

        if (escenariosCompletos >= 3)
        {
            JuegoCompletado(true);
        }
        else
        {
            SiguienteEscen();
        }
    }

    public void EscenarioPerdido()
    {
        if (!juegoActi) return;

        IntentosFallidos();
        answer.PlayOneShot(wrongAnswer);

        if (intentosRestantes > 0)
        {
            SiguienteEscen();
        }
    }

    public void SiguienteEscen()
    {
        indexEscen++;

        ActualizarTimer();
        ActivarPanel();
    }

    public void ActualizarTimer()
    {
        tiempoRestante = tiempoPorEscenario;
    }

    public void ActivarPanel()
    {
        for (int i = 0; i < miniNiveles.Length; i++)
        {
            if (miniNiveles[i] != null)
            {
                miniNiveles[i].SetActive(i == indexEscen);
            }
        }
    }
}
