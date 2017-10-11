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
        
    }
    IEnumerator Direction()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 diff = transform.position - prev;       
        transform.rotation = Quaternion.LookRotation(diff);
        Debug.Log("X座標は" + diff.x);
        Debug.Log("Y座標は" + diff.y);
        Debug.Log("Z座標は" + diff.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("StartCoroutine始めるよ");
            prev = transform.position;
            StartCoroutine("Direction");
        }
    }
}
