using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    InputAction move;
    InputAction run;
    InputAction interactuar;

    CharacterController controller;
    public SODatosJugador jugador;

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



    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        run = InputSystem.actions.FindAction("Sprint");
        interactuar = InputSystem.actions.FindAction("Interact");
        originalSpeed = speed;


        controller = GetComponent<CharacterController>();


        //Carga la partida, se verifica con una bool ya que la escena cargada y la pos solo deberian de verse al cargar partida, no en cada cambio de escena
        if (firstLoad)
        {
            CargaraPartida();

            firstLoad = false;
        }

        //Si se guardo el juego al cerrar, guarda la posicion, si tiene la key, mueve al player a esa posicion en la escena guardada
        //El unico error que hay es que no he encontrado la forma que solo pase a la hora de cargar la partida
        //Ya que solo en el start me funciona pero carga la posicion en cada escena
        if (PlayerPrefs.HasKey("PosicionX"))
        {
            float x = PlayerPrefs.GetFloat("PosicionX");
            float y = PlayerPrefs.GetFloat("PosicionY");
            float z = PlayerPrefs.GetFloat("PosicionZ");

            Vector3 savedPosition = new Vector3(x, y, z);
            controller.enabled = false;
            transform.position = savedPosition;
            controller.enabled = true;
        }



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

        if (run.IsPressed())
        {
            speed = originalSpeed * 2;
        }

        if (interactuar.WasPressedThisFrame())
        {
            Debug.Log("Has interactuado!");
        }
    }

    private void OnApplicationQuit()
    {
        jugador.posJug = transform.position;

        jugador.Guardado();
    }

    public void CargaraPartida()
    {
        //Verifica si ya hay una escena guardada, de ser asi compara si la escena desde donde se da play es igual a la escena guardada
        //Si es diferente se carga la escena
        //Si es igual, no pasa nada
        if (PlayerPrefs.HasKey("EscenaActu"))
        {
            int escenaGuardada = PlayerPrefs.GetInt("EscenaActu");
            int escenaActual = SceneManager.GetActiveScene().buildIndex;

            if (escenaActual != escenaGuardada)
            {
                SceneManager.LoadScene(escenaGuardada);
                return;
            }
        }
        else
        {
            Debug.Log("No has guardado nada!");
        }

    }
}
