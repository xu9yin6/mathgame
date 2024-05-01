using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 加积分机制 : MonoBehaviour
{
    public Text 显示积分;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 100;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        显示积分.text = "积分: " + score.ToString();
    }
}


