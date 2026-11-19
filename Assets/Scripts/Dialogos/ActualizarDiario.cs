using UnityEngine;

public class ActualizarDiario : MonoBehaviour
{
    [SerializeField]
    JournalEntry journalEntry;
    [SerializeField]
    DiarioManager actual;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(journalEntry != null)
            {
                journalEntry.Aumentar();
                actual.UIEntrada();
                gameObject.SetActive(false);
            }
        }
    }
}
