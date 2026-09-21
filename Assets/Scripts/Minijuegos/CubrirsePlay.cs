using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubrirsePlay : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CubriseGame game;

    Vector3 dir;
    InputAction derecha;
    InputAction izquierda;

    bool isCovered = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        derecha = InputSystem.actions.FindAction("Derecha");
        izquierda = InputSystem.actions.FindAction("Izquierda");
    }

    // Update is called once per frame
    void Update()
    {
        if (derecha.IsPressed())
        {
            dir = Vector3.right;
        }

        if(izquierda.IsPressed())
        {
            dir = Vector3.left;
        }

        transform.position += dir * speed * Time.deltaTime;

        if (!isCovered)
        {
            game.Descubierto();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Umbrella"))
        {
            isCovered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Umbrella"))
        {
            isCovered = false;
        }
    }
}
