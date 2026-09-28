using System.Collections;
using TMPro;
using UnityEngine;

/*
 * Encargado del minijuego de destruir reportes
 * hereda de minigame y spawnea tambien los reportes destruir cada cierto tiempo
 * y cuando de destruye cierta cantidad, se completa
 */
public class AmongUsAsteroids : Minigame
{
    [Header("Informacion")]
    [SerializeField] private float spawnTime;
    [SerializeField] private int reportesADestruir = 20;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private GameObject reportePrefab;
    [SerializeField] private TMP_Text textoMini;

    private int reportes;

    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;

        reportes = 0;

        StartCoroutine(SpawnAsteroides());

        textoMini.text = "Dale click a los reportes para romperlos. Reportes destruidos: " + reportes + "/" + reportesADestruir;


    }

    protected override void Update()
    {
        textoMini.text = "Dale click a los reportes para romperlos. Reportes destruidos: " + reportes + "/" + reportesADestruir;
    }

    
    private IEnumerator SpawnAsteroides()
    {
        while (reportes < reportesADestruir && reportePrefab != null)
        {
            Transform puntos = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            GameObject newRep = Instantiate(reportePrefab, puntos.position, Quaternion.identity);

            if (newRep.TryGetComponent<ReportAsteroids>(out ReportAsteroids script))
            {
                script.AgregasSpeed(this);
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void ReporteDestruido()
    {
        if (!juegoActi) return;

        reportes++;
        
        if(reportes >= reportesADestruir)
        {
            JuegoCompletadoTrabajo(true);
        }
        
    }
}
