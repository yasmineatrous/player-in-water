using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]  private float speed;
     [SerializeField]  private float speed2;
    // Start is called before the first frame update
    void Start()
    {
        
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.AddForce(Vector3.right*speed,ForceMode.Acceleration);
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag.Equals("waters"))
       {
         
           rb.velocity = new Vector3 (0,0,-1 * Time.deltaTime * speed2);
           Debug.Log("Current Velocity: " + rb.velocity);
        }

    }

    private void OnTriggerEnter(Collider collision) 
   {
        if (collision.gameObject.tag.Equals("coin"))
        {
            collision.gameObject.SetActive(false);
            StartCoroutine(ReactivateAfterDelay(collision.gameObject, 3f));
         
        }

    }

     private IEnumerator ReactivateAfterDelay(GameObject objToReactivate, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reactivate the object after the specified delay
        objToReactivate.SetActive(true);
    }
}
