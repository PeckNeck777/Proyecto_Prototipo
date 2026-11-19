using TMPro;
using UnityEngine;

/*
 * Minijuego del kahoot, se presenta una serie de preguntas
 * Estas son incorrectas si no se selecciona la respuesta correcta
 * o si se acaba el tiempo
 * al responder 10 preguntas correctas se gana el minijuego
 * Si se tienen 3 intentos fallidos, se pierde el minijuego
 */
public class KahotGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int respuestasNecesitadas = 10;
    [SerializeField] private int respuestas = 0;
    [SerializeField] private int intentos = 3;
    [SerializeField] private float timer = 30f;
    [SerializeField] private GameObject[] panelPregunta;
    [SerializeField] private AudioClip wrongAnswer;
    [SerializeField] private AudioClip correctAnswer;
    [SerializeField] private AudioSource answer;

    private int indicePreg = 0;

    [Header("UI References")]
    [SerializeField] private TMP_Text textoTimer;
    [SerializeField] private TMP_Text textoScore;
    [SerializeField] private TMP_Text textoIntentos;

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
            textoTimer.text = "Tiempo restante para la pregunta: " + Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }


        if (tiempoRestante <= 0)
        {
            RespuestasIncorrectas();
        }

        textoIntentos.text = "Intentos restantes: " + intentosRestantes.ToString() + "/3";
    }

    public void AumentarRespuestasCorrectas()
    {
        respuestas++;
        ActualizarUI();
        answer.PlayOneShot(correctAnswer);

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
        answer.PlayOneShot(wrongAnswer);

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
