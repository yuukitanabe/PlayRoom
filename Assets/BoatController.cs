using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

    private float speed = 3.5f;

    Vector3 prev;

    private float timeElapsed;

    // Use this for initialization
    void Start () {

        this.GetComponent<Rigidbody>().AddForce(
            (transform.forward ) * speed,
             ForceMode.VelocityChange);

        timeElapsed = 0.0f;        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        StartCoroutine("Direction");
    }
    IEnumerator Direction()
    {
        Vector3 diff = transform.position - prev;
        yield return new WaitForSeconds(0.1f);
        transform.rotation = Quaternion.LookRotation(diff);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
           
            prev = transform.position;
            
        }
    }
}
