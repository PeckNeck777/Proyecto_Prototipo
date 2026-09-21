using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDropGame : Minigame
{
    [Header("Informacion")]
    [SerializeField] private float spawnTime;
    [SerializeField] private int maxObjetos = 10;
    [SerializeField] private Transform[] objectsPoint;
    [SerializeField] private GameObject[] objetos;

    [SerializeField] private int objetosRestantes;
    [SerializeField] private int objetosCompletos;

    [SerializeField] private TMP_Text tiempores;

    public override void StartGame()
    {
        base.StartGame();
        type = MinigameType.Tiempo;
        duracion = 60f;

        Time.timeScale = 0;

        objetosRestantes = 0;
        objetosCompletos = 0;

        InvokeRepeating("OjectsSpawn", 0f, spawnTime);

        

    }

    protected override void Update()
    {
        base.Update();
       
        if (!juegoActi) return;

        if (tiempores != null)
        {
            tiempores.text = Mathf.CeilToInt(tiempoRestante).ToString() + "s";
        }

        if (tiempoRestante <= 5)
        {
            CancelInvoke();
        }

    }


    public void OjectsSpawn()
    {

        if (objetosRestantes <= maxObjetos && objectsPoint.Length >= 0 && objetos.Length >= 0)
        {
            Transform randPos = objectsPoint[Random.Range(0, objectsPoint.Length)];
            GameObject randObj = objetos[Random.Range(0, objetos.Length)];

            GameObject newObj = Instantiate(randObj, randPos.position, randPos.rotation);
            objetosRestantes++;
        }
    }

    public void ObjetoPuesto()
    {
        if (!juegoActi) return;
        objetosRestantes--;
        objetosCompletos++;
    }

    public void ObjetoRetirado()
    {
        if (!juegoActi) return;
        objetosRestantes++;
        objetosCompletos--;
    }

    public override void TimeOut()
    {
        if (!juegoActi) return;

        bool ganar = (objetosRestantes <= 0 && objetosCompletos > 0);

        CancelInvoke();
        JuegoCompletado(ganar);
    }

}
