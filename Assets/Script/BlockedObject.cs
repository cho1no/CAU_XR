using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedObject : MonoBehaviour
{
    Rigidbody2D rb;
    public bool ishit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (ishit)
        //{
        //    transform.Rotate(0, 0, 10 * Time.deltaTime) ;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("NormalShot"))
        {
            rb.velocity += (new Vector2(5, 10));
            ishit = true;
        }
    }
}
