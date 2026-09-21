using System.Collections;
using UnityEngine;

public class AmongUsAsteroids : Minigame
{
    [Header("Informacion")]
    [SerializeField] private float spawnTime;
    [SerializeField] private int reportesADestruir = 20;
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private GameObject reportePrefab;

    private int reportes;

    public override void StartGame()
    {
        base.StartGame();

        type = MinigameType.Tiempo;

        reportes = 0;

        StartCoroutine(SpawnAsteroides());


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
            JuegoCompletado(true);
        }
        
    }
}
