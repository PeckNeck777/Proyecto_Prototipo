using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class OldManConsMove : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private Transform puntoDer;
    [SerializeField] private Transform puntoIzq;
    [SerializeField] private OldManConsMini game;
    bool isInArea;
    bool moverDer = true;

    InputAction catchKey;

    private void Start()
    {
        catchKey = InputSystem.actions.FindAction("Catch");
    }


    private void Update()
    {

        Transform objetivo;

        if(moverDer)
        {
            objetivo = puntoDer;
        }
        else
        {
            objetivo = puntoIzq;
        }

        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo.position) < 0.1f)
        {
            moverDer = !moverDer;
        }

        if (catchKey.WasPressedThisFrame())
        {
            if (isInArea)
            {
                game.CosoitosCapturados();
            }
        }
        else
        {
            Debug.Log("Oh oh");
        }

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            isInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            isInArea = false;
        }
    }
}
