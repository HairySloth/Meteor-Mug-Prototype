using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;
    public GameObject proj;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public bool fireReady = true;


    private void Start()
    {

        fireReady = true;
        proj = GameObject.FindWithTag("Projectile");
    }

    public int health = 5;
    public void getHit()
    {
        health--;
    }






    private void Update()
    {
        if (health < 0)
        {
            gameObject.SetActive(false);
        }

        if (fireReady)
        {
            StartCoroutine(Fire());
        }


        //find the vector pointing from our position to the target
        _direction = (Target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
    }


    public IEnumerator Fire()
    {
        fireReady = false;
        Instantiate(proj, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(3f);
        fireReady = true;

    }





}
