using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 跳转场景 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiaozhuan"))
        {
            Destroy(other.gameObject);
            跳转();
        }
    }

    public void 跳转()
    {
        SceneManager.LoadScene("main");
    }
}
