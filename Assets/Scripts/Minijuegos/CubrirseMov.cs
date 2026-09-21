using UnityEngine;
using UnityEngine.Rendering;

public class CubrirseMov : MonoBehaviour
{
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] private float speed;


    private int rando;
    public float time;
    public float change = 5f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= change)
        {
            time = 0;
            rando = Random.Range(0, 10);
        }

        if(rando > 5)
        {
            MoverseIzqu();
        }
        else
        {
            MoverseDer();
        }
    }

    public void MoverseIzqu()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntoB.position, speed);
    }

    public void MoverseDer()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntoA.position, speed);
    }
}
