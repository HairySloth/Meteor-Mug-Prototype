using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public Animator gunAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunAnim.Play("Shoot");


            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.transform.gameObject.GetComponent<Enemy>() != null)
                {
                    hit.transform.gameObject.GetComponent<Enemy>().getHit();

                }
            }

        }
    }


}
