using TMPro;
using UnityEngine;

/*
 * Encargado de manerjar el resto de la UI en los minijuegos
 * Por ejemplo cuanto tiempo falta o cuales son as instrucciones y controles
 * Antes de iniciar el minijuego
 */
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    bool trabajoOpen = false;

    [SerializeField] GameObject instrucciones;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject winScreenTrabajo;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject textoControles;
    [SerializeField] GameObject textoInstrucciones;
    [SerializeField] TMP_Text textoTareaTrabajo;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (trabajoOpen)
        {
            Invoke("DesTrabajo", 2.5f);
        }
    }
    public void QuitarIntrucciones()
    {
        Time.timeScale = 1.0f;

        instrucciones.SetActive(false);
    }

    public void CambiarTextoControles()
    {
            textoControles.SetActive(true);
            textoInstrucciones.SetActive(false);    

    }

    public void CambairTectoInstrucciones()
    {
        textoControles.SetActive(false);
        textoInstrucciones.SetActive(true);

    }

    public void Win()
    {
        winScreen.SetActive(true);
    }

    public void WinTrabajo()
    {
        trabajoOpen = true; 
        winScreenTrabajo.SetActive(true);
    }

    public void DesTrabajo()
    {
        trabajoOpen = false;
        winScreenTrabajo.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void TextoTarea()
    {
        textoTareaTrabajo.gameObject.SetActive(true);   
    }

    public void DesTextoTarea()
    {
        textoTareaTrabajo.gameObject.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
