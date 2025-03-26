using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinMagnet : MonoBehaviour
{
    public Transform TrashCan;
    public float basePullSpeed = 0.5f; // Basisgeschwindigkeit
    private float pullSpeed; // Dynamische Geschwindigkeit

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Trash"))
        {
            Rigidbody trashRb = other.GetComponent<Rigidbody>();
            if (trashRb != null)
            {
                // Passe die Geschwindigkeit basierend auf der Eintrittsgeschwindigkeit an
                float entrySpeed = trashRb.velocity.magnitude;
                pullSpeed = Mathf.Max(basePullSpeed, entrySpeed); // Mindestens die Basisgeschwindigkeit verwenden
            }
            else
            {
                pullSpeed = basePullSpeed; // Fallback, falls kein Rigidbody vorhanden ist
            }

            StartCoroutine(MoveToTrashCan(other.gameObject));
        }
    }

    private IEnumerator MoveToTrashCan(GameObject trash)
    {
        Rigidbody trashRb = trash.GetComponent<Rigidbody>();
        if (trashRb != null)
        {
            trashRb.isKinematic = true; // Deaktiviere physikalische Einflüsse während der Bewegung
        }

        while (trash != null && Vector3.Distance(trash.transform.position, TrashCan.position) > 0.1f)
        {
            // Bewege das Objekt schrittweise zur TrashCan
            trash.transform.position = Vector3.MoveTowards(
                trash.transform.position,
                TrashCan.position,
                pullSpeed * Time.deltaTime
            );

            yield return null; // Warte bis zum nächsten Frame
        }

        if (trash != null)
        {
            // Stelle sicher, dass das Objekt genau an der TrashCan-Position landet
            trash.transform.position = TrashCan.position;

            if (trashRb != null)
            {
                trashRb.isKinematic = false; // Reaktiviere physikalische Einflüsse
            }
        }
    }
}