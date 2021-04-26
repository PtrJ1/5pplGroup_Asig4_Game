using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEF : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disaPear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator disaPear()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
         
        }
    }
}
