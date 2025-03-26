using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinMagnet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // logic when the object enters the triggerarea
        if(other.transform.CompareTag("Trash"))
        {
            other.transform.position = this.transform.position;
            Destroy(other.gameObject);
        }

    }
}
