using TMPro;
using UnityEngine;

public class CubriseGame : Minigame
{

    [Header("Informacion")]
    [SerializeField] private float porcentajeDescubierto;
    [SerializeField] private TMP_Text textoTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;
        Time.timeScale = 0;
        duracion = 60f;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (textoTimer != null)
        {
            textoTimer.text = Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }
    }

    public void Descubierto()
    {
        porcentajeDescubierto += 2 * Time.deltaTime;

        if(porcentajeDescubierto >= 100)
        {
            JuegoCompletado(false);
        }
    }
}
