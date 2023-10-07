using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private float speed;

    private PlayerRagdoll ragdoll;

    private bool switching = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ragdoll= GetComponent<PlayerRagdoll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A)) 
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            switching = !switching;
            SwitchRagdollState();
        }
    }

    void SwitchRagdollState()
    {
        if (!ragdoll.RagdollActive)
            ragdoll.EnableRagdoll();
        else
            ragdoll.EnableAnimator();
        

    }


}
