using UnityEngine;
using UnityEngine.InputSystem;

public class TareaFisica : MonoBehaviour
{
    [SerializeField] Minigame tareaita;
    [SerializeField] Camera camCQ;
    bool completa = false;
    InputAction interactuar;

    private void Start()
    {
        interactuar = InputSystem.actions.FindAction("Interact");
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

    private void OnTriggerStay(Collider other)
    {
        if (completa) return;

        if (other.gameObject.CompareTag("Player"))
        {
            if (interactuar != null && interactuar.WasPressedThisFrame())
            {
                
                if(Camera.main != null)
                {
                    camCQ.gameObject.SetActive(true);
                }

                tareaita.gameObject.SetActive(true);
                tareaita.StartGame();
            }
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
            }
        }
    }
}
