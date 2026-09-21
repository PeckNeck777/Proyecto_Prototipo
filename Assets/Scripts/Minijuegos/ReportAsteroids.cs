using UnityEngine;

public class ReportAsteroids : MonoBehaviour
{
    [SerializeField] private int minVel;
    [SerializeField] private int maxVel;
    [SerializeField] AmongUsAsteroids game;

    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void AgregasSpeed(AmongUsAsteroids controlles)
    {
        game = controlles;

        Vector2 direccion = Random.insideUnitCircle.normalized;

        float velocidad = Random.Range(minVel, maxVel);

        body.linearVelocity = direccion * velocidad;
    }

    private void OnMouseDown()
    {
        game.ReporteDestruido();

        Destroy(gameObject);
    }
}
