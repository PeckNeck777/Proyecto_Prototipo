using TMPro;
using UnityEngine;

/*
 * Juego de ingresar la misma palabra
 * Se tienen 3 rondas, cada una conformada por una minironda
 * Las minirondas son la dificultad que se tiene
 * Al completar 5 mini rondas se pasa de ronda
 * Cada minironda tiene ciertos intentos, si se fallan en todos se pierde
 * Si se ganan las 3 rondas se gana el juego
 * Cada minironda da una palabra aleatoria que el jugador debe ingresar en un tiempo determinado
 */
public class SameWordGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private TMP_Text textoIngresar;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text timerRonda;
    [SerializeField] private TMP_Text intentos;
    [SerializeField] private AudioClip wrongAnswer;
    [SerializeField] private AudioClip correctAnswer;
    [SerializeField] private AudioSource answer;

    [Header("Ronda 1")]
    [SerializeField] private string[] Palabras1;
    [SerializeField] private float tiempoRonda = 6f;

    [Header("Ronda 2")]
    [SerializeField] private string[] Palabras2;
    [SerializeField] private float tiempoRonda2 = 10f;

    [Header("Ronda 3")]
    [SerializeField] private string[] Palabras3;
    [SerializeField] private float tiempoRonda3 = 20f;

    private int rondaActu = 0;
    private int totalRondas = 3;
    private int miniRonda = 0;
    private string fraseEntrgada;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void StartGame()
    {
        base.StartGame();
        type = MinigameType.Intentos;

        rondaActu = 1;
        intentosRestantes = 5;
        CargarRonda();

        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


        intentos.text = "Intentos restantes para esta frase: " + intentosRestantes.ToString();
        timerRonda.text = "Tiempo restante: " + tiempoRestante.ToString("F0") + "Seg.";
    }


    public override void TimeOut()
    {
        if (!juegoActi) return;

        IntentosFallidos();
        answer.PlayOneShot(wrongAnswer);

        if (juegoActi)
        {
            CargarRonda();
        }
    }
    public void CargarRonda()
    {
        inputField.text = "";

        switch(rondaActu)
        {
            case 1:
                fraseEntrgada = ObtenerFraseX(Palabras1);
                duracion = tiempoRonda;
                break;


            case 2:
                fraseEntrgada = ObtenerFraseX(Palabras2);
                duracion = tiempoRonda2;
                break;


            case 3:
                fraseEntrgada = ObtenerFraseX(Palabras3);
                duracion = tiempoRonda3;
                break;
        }

        tiempoRestante = duracion;
        timerRonda.text = "Tiempo restante: " + tiempoRestante.ToString("F0") + "Seg.";
        textoIngresar.text = fraseEntrgada;
        inputField.ActivateInputField();
    }

    private string ObtenerFraseX(string[] listongo)
    {
        if (listongo.Length == 0) return "Comeme los huevos";
        return listongo[Random.Range(0, listongo.Length)];
    }

    public void Validar(string texto)
    {
        if(texto.Trim().ToUpper() == fraseEntrgada.Trim().ToUpper())
        {
            miniRonda++;
            intentos.text = intentosRestantes.ToString();
            answer.PlayOneShot(correctAnswer);

            if (miniRonda >= 5)
            {
                miniRonda = 0;
                rondaActu++;
                intentosRestantes = 5;
            }
            if(rondaActu > totalRondas)
            {
                JuegoCompletado(true);
            }
            else
            {
                CargarRonda();
            }
        }
        else
        {
            IntentosFallidos();
            intentos.text = "Intentos restantes para esta frase: " + intentosRestantes.ToString();
            answer.PlayOneShot(wrongAnswer);
        }
    }
}
