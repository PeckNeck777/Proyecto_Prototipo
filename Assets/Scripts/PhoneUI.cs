using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour
{
    [Header("Info Telefono")]
    [SerializeField] private GameObject phonePanel;
    [SerializeField] private GameObject energiaPanel;
    [SerializeField] private GameObject mascaraPanel;
    [SerializeField] private GameObject voluntadPanel;
    [SerializeField] private Image energiaImage;
    [SerializeField] private Image mascaraImage;
    [SerializeField] private Image voluntadImage;
    [SerializeField] private TMP_Text diaHora;
    [SerializeField] private bool telefonoAbrido = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleTelefono();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Stats.EM += 15;
            Stats.MS += 20;
            Stats.VV += 20;
            ActualizarRellenoActual();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Stats.EM -= 15;
            Stats.MS -= 20;
            Stats.VV -= 20;
            ActualizarRellenoActual();
        }

    }

    private void ActualizarRellenoActual()
    {
        if (energiaPanel.activeSelf) MostrarEnergia();
        if (mascaraPanel.activeSelf) MostrarMascara();
        if (voluntadPanel.activeSelf) MostrarVoluntad();
    }
    public void ToggleTelefono()
    {
        telefonoAbrido = !telefonoAbrido;
        phonePanel.SetActive(telefonoAbrido);

        if(telefonoAbrido)
        {
            ActualizarPantalla();
            MostrarEnergia();
        }
    }

    public void ActualizarPantalla()
    {
        diaHora.text = "Día: " + ObtenerDia(Stats.DiaActual) + " | " + ObtenerHora(Stats.HoraActual);
    }
   

    public void MostrarEnergia()
    {
        ActivarPanel(energiaPanel);
        energiaImage.fillAmount = Stats.EM / 100f;
    }

    public void MostrarMascara()
    {
        ActivarPanel(mascaraPanel);
        mascaraImage.fillAmount = Stats.MS / 100f;
    }               

    public void MostrarVoluntad()
    {
        ActivarPanel(voluntadPanel);
        voluntadImage.fillAmount = Stats.VV / 100f;
    }

    public void ActivarPanel (GameObject phonePanel)
    {
        energiaPanel.SetActive(false);
        mascaraPanel.SetActive(false);
        voluntadPanel.SetActive(false);

        if(phonePanel !=  null)
        {
            phonePanel.SetActive(true);
        }
    }

    public string ObtenerHora(int hora)
    {
        switch (hora)
        {
            case 1:
                return "Mañana";
            case 2:
                return "Tarde";
            case 3:
                return "Noche";
            default:
                return  "Mañana";
        }
    }

    public string ObtenerDia(int dia)
    {
        switch (dia)
        {
            case 1:
                return "Lunes";
            case 2:
                return "Martes";
            case 3:
                return "Miercoles";
            case 4:
                return "Jueves";
            case 5:
                return "Viernes";
            case 6:
                return "Sabado";
            case 7:
                return "Domingo";
            default:
                return "Mañana";
        }
    }
}
