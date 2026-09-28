using UnityEngine;


/*
 * Le da movilidad a los reportes del minijuego
 * Para que salgan a distinta velocidad
 * Dentro de un punto random de un circulo
 */
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}
