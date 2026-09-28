using System;
using UnityEngine;



/*
 * Script base para la gestión y control de minijuegos. Define la estructura de datos 
 * y las reglas de victoria/derrota para las distintas modalidades del juego:
 * 
 * 1. Minijuegos de Aguante (Supervivencia): El jugador debe resistir durante un tiempo 
 *    determinado hasta que el contador llegue a cero para completar con éxito el desafío.
 * 2. Minijuegos de Cumplir Objetivos: El jugador cuenta con un tiempo límite para realizar 
 *    una acción específica. Si el tiempo expira antes de completar el objetivo, se considera derrota.
 * 3. Minijuegos de Intentos (Fallos limitados): El jugador debe ejecutar acciones de precisión. 
 *    Cada error resta un intento disponible; al llegar a 0 intentos, el minijuego finaliza en derrota.
 */
public abstract class Minigame : MonoBehaviour
{
    public enum MinigameType { Tiempo, Intentos, Cumplir }

    [Header("Settings del Minijuego")]
    [SerializeField] protected float duracion = 60f;
    [SerializeField] protected int attempts = 3;
    [SerializeField] protected MinigameType type;

    protected bool juegoActi;
    protected bool juegoTerminado;
    protected bool tareaCompletada;

    public event Action<bool> tareaCom;

    protected float tiempoRestante;
    protected int intentosRestantes;

    public virtual void StartGame()
    {
        juegoActi = true;
        tiempoRestante = duracion;
        intentosRestantes = attempts;
    }

    protected virtual void Update()
    {
        if (!juegoActi) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            TimeOut();
        }
    }

    public void IntentosFallidos()
    {
        if (!juegoActi) return;

        intentosRestantes--;
        Debug.Log("Te quedan " + intentosRestantes + " intentos.");

        if (intentosRestantes <= 0)
        {
            JuegoCompletado(false);
            UIManager.instance.GameOver();
        }
    }

    public virtual void TimeOut()
    {
        if (!juegoActi) return;

        bool ganacion = (type == MinigameType.Tiempo || type == MinigameType.Cumplir);
        JuegoCompletado(ganacion);
    }

    public void JuegoCompletado(bool ganacion)
    {
        if (!juegoActi) return;

        juegoActi = false;
        juegoTerminado = ganacion;

        if (ganacion)
        {
            UIManager.instance.Win();
            Debug.Log("¡Ganaste el minijuego!");
        }
        else
        {
            UIManager.instance.GameOver();
            Debug.Log("¡Perdiste el minijuego!");
        }

   
        Complete(ganacion);

    }

    public void JuegoCompletadoTrabajo(bool ganacion)
    {
        if (!juegoActi) return;

        juegoActi = false;
        juegoTerminado = ganacion;

        if (ganacion)
        {
            UIManager.instance.WinTrabajo();
            Debug.Log("¡Ganaste el minijuego!");
        }

        Complete(ganacion);

    }

    public void Complete(bool victory)
    {
        juegoActi = false;
        tareaCompletada = true;
        tareaCom?.Invoke(victory);
        gameObject.SetActive(false);
    }

}
