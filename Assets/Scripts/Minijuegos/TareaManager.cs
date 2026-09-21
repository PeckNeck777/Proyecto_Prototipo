using System;
using UnityEngine;

public class TareaManager : MonoBehaviour
{
    public static TareaManager instance;

    [SerializeField] private int tareasHechas = 5;
    [SerializeField] private int tareas = 0;

    public event Action<int, int> OnTareasCompletas;
    public event Action OnTareasFULL;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        OnTareasCompletas?.Invoke(tareas, tareasHechas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TareaaFiniquitada()
    {
        tareas ++;
        gameObject.SetActive(false);
        OnTareasCompletas?.Invoke(tareas, tareasHechas);

        if(tareas >= tareasHechas)
        {
            OnTareasFULL?.Invoke();
            Debug.Log("Full tareas terminadas loco!");
        }
    }
}
