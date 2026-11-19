using UnityEngine;
using UnityEngine.UI;


/*
 *   Script estático que administra el estado persistente de la partida. 
 *   Almacena métricas emocionales, progreso del día actual, la escena activa y la posición 
 *   del jugador en el mapa.
 * 
 */

public enum EstadosAlicia
{
    NoHablado,
    Invitada,
    NoInvitada
}
public static class Stats 
{
    //Variables Stats
    static int energiaMental = 100;
    static int mascaraSocial = 100;
    static int voluntadDeVivir = 100;

    //Variables Alicia

    static EstadosAlicia estadoAlicia  = EstadosAlicia.NoHablado;

    //Variables de Escena
    static string ultimaEscena = "";

    //Llaves
    static string kMascaraSocial = "kMasc", kEnergiaMental = "kEnM", kVoluntadDeVivir = "kVV", kUltimaEscena = "kUltEs", kHabloConAlicia = "kAlicia";


    //Cargar y modificar stats durante el jogo
    static public int EM { get => energiaMental; set => energiaMental = (Mathf.Clamp(value, 0, 100)); }
    static public int MS { get => mascaraSocial; set => mascaraSocial = (Mathf.Clamp(value, 0, 100)); }
    static public int VV { get => voluntadDeVivir; set => voluntadDeVivir = (Mathf.Clamp(value, 0, 100)); }

    static public EstadosAlicia EstadoAlicia { get { return estadoAlicia; } set { estadoAlicia = value; } }

    static public string UltimaEscena { get { return ultimaEscena; } set {  ultimaEscena = value; } }  

    //Obtener las llaves para cargar y guardar datos

    static public string KMascaraSocial { get { return kMascaraSocial; } }

    static public string KEnergiaMental { get { return kEnergiaMental; } }

    static public string KVoluntadDeVivir { get { return kVoluntadDeVivir; } }

    static public string KHabloAlicia { get {return kHabloConAlicia; } }

    static public string KUltimaEscena { get {  return kUltimaEscena; } }   

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
