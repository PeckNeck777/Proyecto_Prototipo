using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Datos Player", menuName = "Pruebasl/Player datos")]
public class SODatosJugador : ScriptableObject
{
    public Vector3 posJug;

    public int numScena;

    public void Guardado()
    {
        PlayerPrefs.SetFloat("PosicionX", posJug.x);
        PlayerPrefs.SetFloat("PosicionY", posJug.y);
        PlayerPrefs.SetFloat("PosicionZ", posJug.z);


        int currentEscena = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("EscenaActu", currentEscena);

        PlayerPrefs.Save();
    }
}
