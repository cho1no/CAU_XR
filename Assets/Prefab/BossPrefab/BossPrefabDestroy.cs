using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrefabDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BPDT", 0.4f);
    }

    // Update is called once per frame
    public void BPDT()
    {
        Destroy(gameObject);
    }
}
