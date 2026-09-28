using TMPro;
using UnityEngine;


/*
 * Minijuego de precision, llamado Old Man Consequences por que de ahi se tuvo la referencia
 * El jugador debera de "capturar" ciertos objetos dentro de un area especifica
 * Hasta capturar cierta cantidad se gana el minijuego
 * Con cada captura, el area cambia de posicion
 */
public class OldManConsMini : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int cososCapturados;
    [SerializeField] private int cososPorCapturar;
    [SerializeField] private GameObject areaChidoLira;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private TMP_Text textoMini;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void StartGame()
    {
        base.StartGame();

        cososCapturados = 0;

        textoMini.text = "Presiona C cuando el cuadro este dentro del area, un total de 5 veces basta!";
    }


    public void CosoitosCapturados()
    {
        cososCapturados++;
        //Destroy(areaChidoLira);

        if(cososCapturados >= cososPorCapturar)
        {
            JuegoCompletadoTrabajo(true);
        }
        else
        {
            int posRandom = Random.Range(0, spawners.Length);

            Vector3 pos = spawners[posRandom].transform.position; 

            areaChidoLira.transform.position = pos;
        }
    }

}
