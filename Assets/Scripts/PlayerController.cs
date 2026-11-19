using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*
 * Encargado de mover al player, velocidad y se encarga de ver
 * los daots guardados (Temporal, en un futuro se va a remover)
 */
public class PlayerController : MonoBehaviour
{
    InputAction move;
    InputAction run;
    InputAction interactuar;

    CharacterController controller;

    Vector3 velocity;
    bool grounded;
    float originalSpeed;

    static bool firstLoad = true;

    [Header("Movimiento")]
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -9.8f;


    [Header("Rotación")]
    [SerializeField] Transform camTransform;
    [SerializeField] bool shouldMovedirection = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //if (Stats.PosJugador != Vector3.zero)
        //{
        //    controller.enabled = false;
        //    transform.position = Stats.PosJugador;
        //    controller.enabled = true;
        //}
    }
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        run = InputSystem.actions.FindAction("Sprint");
        interactuar = InputSystem.actions.FindAction("Interact");
        originalSpeed = speed;
    }

    void Update()
    {

        grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector2 input = move.ReadValue<Vector2>();
        Vector3 dir = forward * input.y + right * input.x;
        controller.Move(dir * speed * Time.deltaTime);

        if (shouldMovedirection && dir.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10 * Time.deltaTime);
        }

        //Stats.PosJugador = transform.position;

        if (run.IsPressed())
        {
            speed = originalSpeed * 2;
        }

        if (interactuar.WasPressedThisFrame())
        {
            Debug.Log("Has interactuado!");
        }
    }

}
