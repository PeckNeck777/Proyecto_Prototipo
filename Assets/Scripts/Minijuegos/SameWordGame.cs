using TMPro;
using UnityEngine;

public class SameWordGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private TMP_Text textoIngresar;
    [SerializeField] private TMP_InputField inputField;

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
        type = MinigameType.Tiempo;

        rondaActu = 1;
        intentosRestantes = 5;
        CargarRonda();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (tiempoRestante <= 0)
        {
            JuegoCompletado(false);
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

            if(miniRonda > 5)
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
        }
    }
}
