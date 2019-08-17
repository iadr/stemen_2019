using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCrash : MonoBehaviour
{
    public int id = 1;
    public float rotation = 10;
    public float speed = 10;
    public Vector3 velocity;
    private string xAxis, yAxis;
    private Rigidbody rb;
    public bool canCheckPiso = true;
    public LayerMask maskPiso;
    public bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xAxis = "Joy"+id+"X";
        yAxis = "Joy"+id+"Y";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!canCheckPiso)
            return;
        CheckPiso();
        if(!onGround)
            return;
        transform.Rotate(0,Input.GetAxis(xAxis) * rotation * Time.deltaTime,0);
        velocity = transform.forward * Input.GetAxis(yAxis) * speed * Time.deltaTime + transform.up * rb.velocity.y;
        rb.velocity = velocity;
        rb.angularVelocity=Vector3.zero;
    }

    void CheckPiso(){
        if(Physics.Raycast(transform.position,-transform.up,0.6f,maskPiso))
            onGround = true;
        else
        {
            onGround = false;
        }
    }

    IEnumerator delayPiso(){
        yield return new WaitForSeconds(0.5f);
        canCheckPiso = true;
    }


    void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Player"){
            Vector3 contactPoint = collision.contacts[0].point - transform.position;
            Debug.Log("collision: "+contactPoint);
            rb.AddForce(-contactPoint.normalized * 5 + transform.up, ForceMode.VelocityChange);
            canCheckPiso = false;
            StartCoroutine(delayPiso());
        }
    }

    public void ReceiveForce(Vector3 direction, float _speed){

    }
}
