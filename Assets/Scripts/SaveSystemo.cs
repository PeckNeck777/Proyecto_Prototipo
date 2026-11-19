using UnityEngine;
using UnityEngine.SceneManagement;
using static Stats;

/*
 *   Administrador de guardar los datos. Verifica la presencia de datos 
 *   guardados para cargarlos al iniciar, de lo contrario, inicializa el estado por defecto 
 *   y permite serializar las estadísticas actuales durante el juego.
 */

public class SaveSystemo : MonoBehaviour
{
    public static SaveSystemo instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SeeStats();
    }
    private void OnApplicationQuit()
    {
        SaveStats();
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause) SaveStats();
    }

    public void SaveStats()
    {
        //Guardar stats
        PlayerPrefs.SetInt(Stats.KMascaraSocial, Stats.MS);
        PlayerPrefs.SetInt(Stats.KEnergiaMental, Stats.EM);
        PlayerPrefs.SetInt(Stats.KVoluntadDeVivir, Stats.VV);

        /*Guardar escena que cargo
         * !!Guardar el juego solo se hace cuando entramos a una nueva escena
         */

        PlayerPrefs.SetInt(Stats.KHabloAlicia, (int)Stats.EstadoAlicia);
        PlayerPrefs.SetString(Stats.KUltimaEscena, SceneManager.GetActiveScene().name);

    }

    /*Permite cargar toda la data del Jogo al presionar un boton de load
      Si queremos mostrar info desde el menu del juego, tipo DeltaruneDeidad
      Hay que modificar el metodo para que cargue la data relevante y la muestre en un objeto de perfil
      Luego al presionar el boton de continuar carga la escena mediante otro metodo
    */
    public void LoadStats()
    {
        if (PlayerPrefs.HasKey(Stats.KUltimaEscena))
        {
            if(PlayerPrefs.GetString(Stats.KUltimaEscena) != "")
            {
                Stats.MS = PlayerPrefs.GetInt(Stats.KMascaraSocial);
                Stats.EM = PlayerPrefs.GetInt(Stats.KEnergiaMental);
                Stats.VV = PlayerPrefs.GetInt(Stats.KVoluntadDeVivir);

                if (PlayerPrefs.HasKey(Stats.KHabloAlicia))
                {
                    Stats.EstadoAlicia = (EstadosAlicia)PlayerPrefs.GetInt(Stats.KHabloAlicia);
                }

                
                SceneManager.LoadScene(PlayerPrefs.GetString(Stats.KUltimaEscena));
            }
        }
    }

    public void SeeStats()
    {
        Debug.Log(Stats.MS);
        Debug.Log(Stats.EM);
        Debug.Log(Stats.VV);

        Debug.Log(Stats.EstadoAlicia);
    }

    //Se llama con el boton de nuevo juego
    public void DeleteData()
    {
        Stats.MS = 100;
        Stats.EM = 100;
        Stats.VV = 100;

        PlayerPrefs.SetInt("CurrentDay", 0);

        Stats.EstadoAlicia = EstadosAlicia.NoHablado;
        Stats.UltimaEscena = "";
    }
}
