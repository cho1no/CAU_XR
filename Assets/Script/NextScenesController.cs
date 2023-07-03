using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScenesController : MonoBehaviour
{
    public string Title;

    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 8f)
        {
            SceneManager.LoadScene(Title);
        }
    }
}
