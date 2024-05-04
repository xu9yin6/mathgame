using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 禁区 : MonoBehaviour
{
    public Text jinqu;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jinqu.gameObject.SetActive(true);
            StartCoroutine(DisablejinquAfterDelay(5f));
        }
    }

    IEnumerator DisablejinquAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        jinqu.gameObject.SetActive(false);
    }
}
