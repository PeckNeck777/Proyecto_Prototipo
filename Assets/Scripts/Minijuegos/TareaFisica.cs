using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Son las tareas fisicas dentro del juego para el ambiente del trabajo
 * Al interactuar con ellas, se activa la tarea y cuando se completa el minijuego se desactiva
 */
public class TareaFisica : MonoBehaviour
{
    [SerializeField] Minigame tareaita;
    [SerializeField] Camera camCQ;
    [SerializeField] GameObject objetungo;
    bool completa = false;
    bool canMakeTarea = false;
    InputAction interactuar;

    private void Start()
    {
        interactuar = InputSystem.actions.FindAction("Interact");
    }

    private void Update()
    {
        if(canMakeTarea)
        {
            if (interactuar != null && interactuar.WasPressedThisFrame())
            {

                if (Camera.main != null)
                {
                    camCQ.gameObject.SetActive(true);
                }

                tareaita.gameObject.SetActive(true);
                objetungo.SetActive(true);
                UIManager.instance.DesTextoTarea();
                tareaita.StartGame();
            }
        }
    }
    public void OnEnable()
    {
        if(tareaita != null)
        {
            tareaita.tareaCom += TareaTerminada;
        }
        
    }

    public void OnDisable()
    {
        if(tareaita != null)
        {
            tareaita.tareaCom -= TareaTerminada;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (completa) return;

        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.instance.TextoTarea();
            canMakeTarea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.instance.DesTextoTarea();
            canMakeTarea = false;
        }
    }


    public void TareaTerminada(bool ganar)
    {
        if (completa) return;

        if (Camera.main != null)
        {
            camCQ.gameObject.SetActive(false);
        }

        if (ganar)
        {
            if (TareaManager.instance != null)
            {
                gameObject.SetActive(false);
                TareaManager.instance.TareaaFiniquitada();
                UIManager.instance.DesTextoTarea();
            }
        }
    }
}
