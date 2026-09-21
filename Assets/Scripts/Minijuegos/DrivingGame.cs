using UnityEngine;
using UnityEngine.InputSystem;

public class DrivingGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private Transform carroParent;
    [SerializeField] private float changeLaneDistance = 3f;
    [SerializeField] private float dodgeSpeed = 12f;
    [SerializeField] private float carSpeed = 15f;

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

        Debug.Log("¡Has colisionado!");
        IntentosFallidos();
    }


}
