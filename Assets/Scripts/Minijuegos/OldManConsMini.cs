using UnityEngine;

public class OldManConsMini : Minigame
{
    [Header("Informacion")]
    [SerializeField] private int cososCapturados;
    [SerializeField] private int cososPorCapturar;
    [SerializeField] private GameObject areaChidoLira;
    [SerializeField] private GameObject[] spawners;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void StartGame()
    {
        base.StartGame();

        cososCapturados = 0;
    }


    public void CosoitosCapturados()
    {
        cososCapturados++;
        //Destroy(areaChidoLira);

        if(cososCapturados >= cososPorCapturar)
        {
            JuegoCompletado(true);
        }
        else
        {
            int posRandom = Random.Range(0, spawners.Length);

            Vector3 pos = spawners[posRandom].transform.position; 

            areaChidoLira.transform.position = pos;
        }
    }

}
