using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/*
 * Se encarga de se los placers de los objetos del minijuego
 * de drag and drop
 * Si se suelta en su area designada de cuenta como objeto puesto
 * de lo contrario no pasa nada
 */
public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private string tagObj;
    [SerializeField] DragAndDropGame game;

    private void OnTriggerEnter(Collider other)
    {
        if (game == null) return;

        if (other.CompareTag(tagObj))
        {
            game.ObjetoPuesto();
            Destroy(other.gameObject);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (game == null) return;

        if (other.CompareTag(tagObj))
        {
            game.ObjetoRetirado();
            Destroy(other.gameObject);

        }
    }
}

