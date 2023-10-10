using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    [SerializeField] GameObject finalTrampoline;
    // Start is called before the first frame update
    void Start()
    {
        finalTrampoline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
            finalTrampoline.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
            finalTrampoline.SetActive(false);
    }
}
