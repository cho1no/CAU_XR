using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DTGO", 0.5f);
    }

    public void DTGO()
    {
        Destroy(gameObject);
    }
}
