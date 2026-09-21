using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    //public enum ObjectTag { Importante, Basura, Utiles}
    [SerializeField] private string tagObj;
    [SerializeField] DragAndDropGame game;
    //[SerializeField] private List<ObjectTag> objectsApproved;

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

