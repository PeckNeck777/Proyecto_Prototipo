using UnityEngine;


/*
 *   Script estático que administra el estado persistente de la partida. 
 *   Almacena métricas emocionales, progreso del día actual, la escena activa y la posición 
 *   del jugador en el mapa.
 * 
 */
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
    static public int MS { get => mascaraSocial; set => mascaraSocial = (Mathf.Clamp(value, 0, 100)); }
    static public int VV { get => voluntadDeVivir; set => voluntadDeVivir = (Mathf.Clamp(value, 0, 100)); }

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
