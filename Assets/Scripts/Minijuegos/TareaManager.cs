using System;
using TMPro;
using UnityEngine;

/*
 * Manager de tareas del trabajo
 * cada vez que se completa una se suscribe al evento y se verifica que se tengan las completas
 * De no tenerlas completas se aumenta el numero de tareas
 * Ya hasta ser igual que las tareas que se deben hacer
 * Se suscribe al evento de tareasFUll y se activa el evento (Que en este caso seria poder irse del trabajo)
 */
public class TareaManager : MonoBehaviour
{
    public static TareaManager instance;

    [SerializeField] private int tareasHechas = 5;
    [SerializeField] private int tareas = 0;
    [SerializeField] private GameObject salir;
    [SerializeField] private TMP_Text incomple;
    [SerializeField] private TMP_Text textoCompleto;

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
            salir.SetActive(true);
            incomple.gameObject.SetActive(false);
            textoCompleto.gameObject.SetActive(true);
            Debug.Log("Full tareas terminadas loco!");
        }
    }
}
