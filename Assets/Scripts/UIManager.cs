using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    

    [SerializeField] GameObject instrucciones;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text textoControles;
    [SerializeField] TMP_Text textoInstrucciones;

    private void Awake()
    {
        instance = this;
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

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void TooglePanel(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
