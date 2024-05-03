using UnityEngine;
using UnityEngine.SceneManagement;

public class 跳转场景 : MonoBehaviour
{
    public int 跳转至BuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            跳转();
        }
    }

    public void 跳转()
    {
        SceneManager.LoadScene(跳转至BuildIndex);
    }
}
