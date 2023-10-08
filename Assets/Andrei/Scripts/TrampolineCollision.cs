using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            Vector3 forceVector = collision.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 30f, ForceMode.VelocityChange);
        }
            
    }
}
