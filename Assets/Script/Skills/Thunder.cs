using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThunder", 0.8f);
    }
    void destroyThunder()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
