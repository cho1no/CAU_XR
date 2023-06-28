using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_FX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFX", 0.5f);
    }
    void DestroyFX()
    {
        Destroy(gameObject);
    }
}
