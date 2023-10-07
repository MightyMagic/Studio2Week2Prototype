using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private PlayerRagdoll ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = Player.GetComponent<PlayerRagdoll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name != "Floor")
        {
            ragdoll.EnableRagdoll();
            Vector3 forceDir = (collision.gameObject.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * 10f, ForceMode.Impulse);
        }
    }
}
