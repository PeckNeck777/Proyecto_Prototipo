using UnityEngine;

public static class Stats 
{
    static int energiaMental = 100;
    static int mascaraSocial = 100;
    static int voluntadDeVivir = 100;
    static int escenaActual = 1;
    static int diaActual = 1;
    static int hora = 1;
    static Vector3 posJugador;

    static public int EM { get => energiaMental; set => energiaMental = (Mathf.Clamp(value, 0, 100)); }
    static public int MS { get => energiaMental; set => mascaraSocial = (Mathf.Clamp(value, 0, 100)); }
    static public int VV { get => energiaMental; set => voluntadDeVivir = (Mathf.Clamp(value, 0, 100)); }

    static public int EscenaActual { get => escenaActual; set => escenaActual = value; }

    static public int DiaActual { get => diaActual; set => diaActual = value; }

    static public int HoraActual { get => hora; set => hora = value; }

    static public Vector3 PosJugador { get => posJugador; set => posJugador = value; }

    public static void ModificarEM(int cantidad)
    {
        EM += cantidad;
    }

    public static void ModificarMS(int cantidad)
    {
        MS += cantidad;
    }

    public static void ModificarVV(int cantidad)
    {
        VV += cantidad;
    }
}
