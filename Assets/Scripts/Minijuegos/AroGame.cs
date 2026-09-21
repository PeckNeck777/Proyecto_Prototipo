using TMPro;
using UnityEngine;

public class AroGame : Minigame
{
    [Header("Información")]
    [SerializeField] private float tiempoPorEscenario = 15f; 
    [SerializeField] private int escenariosCompletos;
    [SerializeField] private GameObject[] miniNiveles;
    [SerializeField] private TMP_Text textoTimer;
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
            textoTimer.text = Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }


        if (tiempoRestante <= 0)
        {
            EscenarioPerdido();
        }
    }

    public void EscenariosExitosos()
    {
        if (!juegoActi) return;

        escenariosCompletos++;

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
