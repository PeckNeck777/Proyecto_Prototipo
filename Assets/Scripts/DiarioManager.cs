using TMPro;
using UnityEngine;

public class DiarioManager : MonoBehaviour
{
    [Header("Info Diario")]
    [SerializeField] GameObject diaroGeneral;
    [SerializeField] GameObject entriesDiario;
    bool diarioAbierto = false;
    bool textoEntrada = false;
    [SerializeField] TMP_Text entradaNueva;
    [SerializeField] GameObject paginaActual;
    [SerializeField] AudioSource pagona;
    [SerializeField] AudioClip actu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToogleDiario();
        }

        if (textoEntrada)
        {
            Invoke("UIDesentrada", 5);
        }
    }

    public void ToogleDiario()
    {
        diarioAbierto = !diarioAbierto;
        diaroGeneral.SetActive(diarioAbierto);
        entriesDiario.SetActive(diarioAbierto);

    }
    public void CambiarPaginaBoton()
    {
        CambioPagina(paginaActual);
                
       
    }
    public void CambioPagina(GameObject actual)
    {
        paginaActual.SetActive(false);
        actual.SetActive(true);
        paginaActual = actual;  
    }

    public void UIDesentrada()
    {
        entradaNueva.text = "";
        textoEntrada = false;
    }
    public void UIEntrada()
    {
        entradaNueva.text = "Has actualizado el diario!";
        pagona.PlayOneShot(actu);
        textoEntrada = true;
    }
}
