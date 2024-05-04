using UnityEngine;
using UnityEngine.UI;

public class 点击跳跃 : MonoBehaviour
{
    Rigidbody2D rg;
    bool canJump = true;

    public Animator anim;

    public float liftForce = 300;

    public Button jumpButton; 

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        RectTransform rectTransform = jumpButton.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(1, 0);
        rectTransform.anchorMax = new Vector2(1, 0);
        rectTransform.pivot = new Vector2(1, 0);
        rectTransform.anchoredPosition = new Vector2(-10, 10); 
    }

    public void OnJumpButtonClick()
    {
        Jump();
        anim.SetTrigger("takeof");
        anim.SetBool("isrunning",true);
    }

    void Jump()
    {
        if (canJump)
        {
            rg.AddForce(Vector2.up * liftForce);
            canJump = false;
            Invoke("ResetJump", 1f);
            anim.SetBool("isrunning",true);
        }
    }

    void ResetJump()
    {
        canJump = true;
        anim.SetBool("isrunning",true);
        
    }
}
