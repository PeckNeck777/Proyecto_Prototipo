using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Datos Player", menuName = "Pruebasl/Player datos")]
public class SODatosJugador : ScriptableObject
{
    public Vector3 posJug;

    public int numScena;

    public void Guardado()
    {
        ////Se guarda la posicion en X, Y y Z del player y el numero de escena dentro del build
        //PlayerPrefs.SetFloat("PosicionX", posJug.x);
        //PlayerPrefs.SetFloat("PosicionY", posJug.y);
        //PlayerPrefs.SetFloat("PosicionZ", posJug.z);


        //int currentEscena = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("EscenaActu", currentEscena);

        //PlayerPrefs.Save();
    }
}
