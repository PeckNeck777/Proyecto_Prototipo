using TMPro;
using UnityEngine;

public class KahotGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int respuestasNecesitadas = 10;
    [SerializeField] private int respuestas = 0;
    [SerializeField] private int intentos = 3;
    [SerializeField] private float timer = 30f;
    [SerializeField] private GameObject[] panelPregunta;

    private int indicePreg = 0;

    [Header("UI References")]
    [SerializeField] private TMP_Text textoTimer;
    [SerializeField] private TMP_Text textoScore;

    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;
        intentosRestantes = intentos;
        respuestas = 0;
        indicePreg = 0;

        Time.timeScale = 0;

        ActualizarTimer();
        ActivarPanel();
        ActualizarUI();
    }

    protected override void Update()
    {
        base.Update();

        if (textoTimer != null)
        {
            textoTimer.text = Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }


        if (tiempoRestante <= 0)
        {
            RespuestasIncorrectas();
        }

    }

    public void AumentarRespuestasCorrectas()
    {
        respuestas++;
        ActualizarUI();

        if (respuestas >= respuestasNecesitadas)
        {
            JuegoCompletado(true); 
        }
        else
        {
            SiguientePregunta();
        }
    }

    public void RespuestasIncorrectas()
    {
        IntentosFallidos(); 
        ActualizarUI();

        if (intentosRestantes > 0)
        {
            SiguientePregunta();
        }
    }

    public void SiguientePregunta()
    {
        if (panelPregunta.Length > 0 && indicePreg < panelPregunta.Length)
        {
            panelPregunta[indicePreg].SetActive(false);
        }

        indicePreg++;

        if (indicePreg >= panelPregunta.Length)
        {
            indicePreg = Random.Range(0, panelPregunta.Length);
        }

        ActualizarTimer();
        ActivarPanel();
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        if (textoScore != null)
        {
            textoScore.text = respuestas.ToString() + "/" + respuestasNecesitadas.ToString();
        }
    }

    public void ActualizarTimer()
    {
        tiempoRestante = timer;
    }

    public void ActivarPanel()
    {
        for (int i = 0; i < panelPregunta.Length; i++)
        {
            if (panelPregunta[i] != null)
            {
                panelPregunta[i].SetActive(i == indicePreg);
            }
        }
    }
}
