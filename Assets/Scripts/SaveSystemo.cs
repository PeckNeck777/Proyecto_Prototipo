using UnityEngine;
using System.IO;
using UnityEngine.Rendering;
using UnityEditor.Rendering;
using System.Collections.Generic;
public class SaveSystemo : MonoBehaviour
{
    public static SaveSystemo instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        SaveStats();
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause) SaveStats();
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("EnergiaMental", Stats.EM);
        PlayerPrefs.SetInt("MascaraSocial", Stats.MS);
        PlayerPrefs.SetInt("VoluntadDeVivir", Stats.VV);
        PlayerPrefs.SetInt("EscenaActiva", Stats.EscenaActual);
        PlayerPrefs.SetInt("DiaActual", Stats.DiaActual);

        PlayerPrefs.SetFloat("PosicionX", Stats.PosJugador.x);
        PlayerPrefs.SetFloat("PosicionY", Stats.PosJugador.y);
        PlayerPrefs.SetFloat("PosicionZ", Stats.PosJugador.z);

        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        PlayerPrefs.GetInt("EnergiaMental", 100);
        PlayerPrefs.GetInt("MascaraSocial", 100);
        PlayerPrefs.GetInt("VoluntadDeVivir", 100);
        PlayerPrefs.GetInt("EscenaActiva", 1);
        PlayerPrefs.GetInt("DiaActual", 1);

        float x = PlayerPrefs.GetFloat("PosicionX", Stats.PosJugador.x);
        float y = PlayerPrefs.GetFloat("PosicionY", Stats.PosJugador.y);
        float z = PlayerPrefs.GetFloat("PosicionZ", Stats.PosJugador.z);

        Stats.PosJugador = new Vector3(x, y, z);
    }
}
