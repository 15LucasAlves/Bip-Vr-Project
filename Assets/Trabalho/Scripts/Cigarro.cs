using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// cigarette blows smoke or not 

public class Cigarro : MonoBehaviour
{
    [SerializeField] private GameObject pontaDoCigarro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            pontaDoCigarro.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            pontaDoCigarro.GetComponent<ParticleSystem>().Stop();
        }
    }
}
