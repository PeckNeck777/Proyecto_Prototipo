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
    [SerializeField] TMP_Text textoControles;
    [SerializeField] TMP_Text textoInstrucciones;
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
            textoControles.gameObject.SetActive(true);
            textoInstrucciones.gameObject.SetActive(false);    

    }

    public void CambairTectoInstrucciones()
    {
        textoControles.gameObject.SetActive(false);
        textoInstrucciones.gameObject.SetActive(true);

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

    public void TooglePanel(GameObject go)
    {
        go.SetActive(!go.activeSelf);
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
