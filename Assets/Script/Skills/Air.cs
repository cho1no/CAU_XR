using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    float posX; float posY;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        Invoke("DestroyWind", 1.5f);
        //StartCoroutine("DW");
    }
    void DestroyWind()
    {
        Destroy(gameObject);
    }
    IEnumerable DW()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(5f*Time.deltaTime, 0, 0));
        transform.localScale += (new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 0));
    }
}
