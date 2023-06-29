using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFX", 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyFX()
    {
        Destroy(gameObject);
    }
}
