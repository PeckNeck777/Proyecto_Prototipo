using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Juego de manejo, se puede cambiar de carriles
 * Evitando los obstaculos
 * Si se llega al final, que es cuando el tiempo se acaba, gana el juego
 * Si se choca 3 veces con el obstaculo pierde
 */
public class DrivingGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private Transform carroParent;
    [SerializeField] private float changeLaneDistance = 3f;
    [SerializeField] private float dodgeSpeed = 12f;
    [SerializeField] private float carSpeed = 15f;
    [SerializeField] private AudioClip choqueCarro;
    [SerializeField] private AudioSource carro;
    [SerializeField] private TMP_Text tiempoCasa;
    [SerializeField] private TMP_Text intentosCarro;

    private int lane = 0;
    private float target;

    private InputAction derecha;
    private InputAction izquierda;

    public override void StartGame()
    {
        base.StartGame();
        type = MinigameType.Tiempo; 
        duracion = 60f;
        attempts = 3;

        lane = 0;
        if (carroParent != null)
        {
            target = carroParent.position.x;
        }
           

        derecha = InputSystem.actions.FindAction("Derecha");
        izquierda = InputSystem.actions.FindAction("Izquierda");

        Time.timeScale = 0;

    }

    protected override void Update()
    {
        base.Update(); 

        if (!juegoActi) return;

        tiempoCasa.text = "Tiempo restante para llegar a casa: " + tiempoRestante.ToString("0F")+" Seg";
        intentosCarro.text = "Choques permitidos: " + intentosRestantes.ToString() + "/3";

        MoversedeCarril();
        MoverseAdelante();
    }

    public void MoversedeCarril()
    {
        if (derecha.WasPressedThisFrame())
        {
            if (lane < 1)
            {
                lane++;
            } 
        }
        else if (izquierda.WasPressedThisFrame())
        {
            if (lane > -1)
            {
                lane--;
            }
        }

        target = lane * changeLaneDistance;
    }

    public void MoverseAdelante()
    {
        if (carroParent == null) return;

        Vector3 pos = carroParent.position;

        pos.z += carSpeed * Time.deltaTime;

        pos.x = Mathf.Lerp(pos.x, target, dodgeSpeed * Time.deltaTime);

        carroParent.position = pos;
    }

    public void ObstaculoHit()
    {
        if (!juegoActi) return;

        carro.PlayOneShot(choqueCarro);

        Debug.Log("¡Has colisionado!");
        IntentosFallidos();
    }


}
