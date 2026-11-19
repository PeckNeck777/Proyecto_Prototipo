using UnityEngine;
using TMPro;
using JetBrains.Annotations;


public enum EstadoDia
{
    DiaMalo,
    DiaRegular,
    DiaBueno
}
public class JournalEntry : MonoBehaviour
{
    [System.Serializable]
    public struct DatosDiario
    {
        [Header("Textos segun el estado Y si Alicia esta invitada")]
        public string textoMalo;
        public string textoRegular;
        public string textoBueno;
        public string aliciaTestoInvitada;
        public string aliciaTestoNaoInvitada;

        [Header("Texto que Pro")]
        public TextMeshProUGUI textoDiario;
        public TextMeshProUGUI textoAlicia;
    }

    [Header("Entradas informacion")]
    public EstadosAlicia nuevoEstado;
    public int voluntadVivir;
    public EstadoDia estadoDia;
    public int diaActu;
    public DatosDiario[] datos;

    int vvGuardada;
    EstadosAlicia aliciaGuardada;

   

    private void Start()
    {
        diaActu = 0;
    }

    private void OnEnable()
    {
        UpdateDiario();
    }
    public void UpdateDiario()
    {
        diaActu = PlayerPrefs.GetInt("CurrentDay", 0);
        voluntadVivir = Stats.VV;
        nuevoEstado = Stats.EstadoAlicia;


        for(int i = 0; i < datos.Length; i++)
        {
            if (datos[i].textoDiario == null) continue;
            int dia = i + 1; 

            if (dia <= diaActu)
            {
                vvGuardada = PlayerPrefs.GetInt("Dia_" + dia + "_VV");
                aliciaGuardada = (EstadosAlicia)PlayerPrefs.GetInt("Dia_" + dia + "_Alicia");


                if (vvGuardada <= 30)
                {
                    estadoDia = EstadoDia.DiaMalo;

                }
                else if (vvGuardada <= 60)
                {
                    estadoDia = EstadoDia.DiaRegular;
                }
                else
                {
                    estadoDia = EstadoDia.DiaBueno;
                }

                switch (estadoDia)
                {
                    case EstadoDia.DiaMalo:

                        if(aliciaGuardada == EstadosAlicia.Invitada)
                        {
                            datos[i].textoDiario.text = datos[i].textoMalo;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoInvitada;
                        }
                        else
                        {
                            datos[i].textoDiario.text = datos[i].textoMalo;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoNaoInvitada;
                        }

                        break;

                    case EstadoDia.DiaRegular:
                        if (aliciaGuardada == EstadosAlicia.Invitada)
                        {
                            datos[i].textoDiario.text = datos[i].textoRegular;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoInvitada;
                        }
                        else
                        {
                            datos[i].textoDiario.text = datos[i].textoRegular;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoNaoInvitada;
                        }
                        break;

                    case EstadoDia.DiaBueno:
                        if (aliciaGuardada == EstadosAlicia.Invitada)
                        {
                            datos[i].textoDiario.text = datos[i].textoBueno;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoInvitada;
                        }
                        else
                        {
                            datos[i].textoDiario.text = datos[i].textoBueno;
                            datos[i].textoAlicia.text = datos[i].aliciaTestoNaoInvitada;
                        }
                        break;
                }
            }
            else
            {
                datos[i].textoDiario.text = "?????\nDia aun no occure, espera un poco mas";
                datos[i].textoAlicia.text  = "???";
            }
        }

        
    }


    public void Aumentar()
    {
        diaActu = PlayerPrefs.GetInt("CurrentDay", 0);
        diaActu++;

        PlayerPrefs.SetInt("Dia_" + diaActu + "_VV", Stats.VV);
        PlayerPrefs.SetInt("Dia_" + diaActu + "_Alicia", (int)Stats.EstadoAlicia);
        PlayerPrefs.SetInt("CurrentDay", diaActu);
        PlayerPrefs.Save();
    }
}
