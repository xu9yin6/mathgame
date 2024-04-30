using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameInput : MonoBehaviour
{

    private void SuanzhuMove1(GameObject moveGameObject, suanzhu zhuzi)
    {
        // 珠子尚未移动，执行移动操作
        zhuzi.MoveDistance = 2;
        Vector3 newPosition = new Vector3(moveGameObject.transform.position.x, moveGameObject.transform.position.y + zhuzi.MoveDistance, moveGameObject.transform.position.z);
        moveGameObject.transform.position = newPosition;

        // 设置 HasMoved 为 true，表示已经移动过
        zhuzi.HasMoved = true;
    }
    private void SuanzhuMove2(GameObject moveGameObject, suanzhu zhuzi)
    {
        zhuzi.MoveDistance = 2;
        Vector3 newPosition = new Vector3(moveGameObject.transform.position.x, moveGameObject.transform.position.y - zhuzi.MoveDistance, moveGameObject.transform.position.z);
        moveGameObject.transform.position = newPosition;
        zhuzi.HasMoved = false;
    }
    private void SuanzhuMove3(GameObject moveGameObject, suanzhu zhuzi)
    {
        zhuzi.MoveDistance = 0.8f;
        Vector3 newPosition = new Vector3(moveGameObject.transform.position.x, moveGameObject.transform.position.y - zhuzi.MoveDistance, moveGameObject.transform.position.z);
        moveGameObject.transform.position = newPosition;
        zhuzi.HasMoved = true;
    }
    private void SuanzhuMove4(GameObject moveGameObject, suanzhu zhuzi)
    {
        zhuzi.MoveDistance = 0.8f;
        Vector3 newPosition = new Vector3(moveGameObject.transform.position.x, moveGameObject.transform.position.y + zhuzi.MoveDistance, moveGameObject.transform.position.z);
        moveGameObject.transform.position = newPosition;
        zhuzi.HasMoved = false;
    }

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                    if (hit.collider != null)
                    {
                        suanzhu suanzhuComponent = hit.collider.gameObject.GetComponent<suanzhu>();

                        if (suanzhuComponent != null)
                        {
                            if (!suanzhuComponent.HasMoved && hit.collider.gameObject.layer == LayerMask.NameToLayer("down"))
                            {
                                int index = suanzhuComponent.gameObjects.IndexOf(hit.collider.gameObject);
                                if(index != 0)
                                {
                                    for(int i = 0; i < index; i++)
                                    {
                                        GameObject obj = suanzhuComponent.gameObjects[i];
                                        suanzhu zhuzi = obj.GetComponent<suanzhu>();
                                        if (!zhuzi.HasMoved)
                                        {
                                            SuanzhuMove1(obj,zhuzi);
                                        }
                                    }
                                }
                                    SuanzhuMove1(hit.collider.gameObject, suanzhuComponent);
                            }
                            else if (suanzhuComponent.HasMoved && hit.collider.gameObject.layer == LayerMask.NameToLayer("down"))
                            {
                                int index = suanzhuComponent.gameObjects.IndexOf(hit.collider.gameObject);
                                if (index != 3)
                                {
                                    for (int i = 3; i > index; i--)
                                    {
                                        GameObject obj = suanzhuComponent.gameObjects[i];
                                        suanzhu zhuzi = obj.GetComponent<suanzhu>();
                                        if (zhuzi.HasMoved)
                                        {
                                            SuanzhuMove2(obj, zhuzi);
                                        }
                                    }
                                }
                                SuanzhuMove2(hit.collider.gameObject, suanzhuComponent);
                            }
                            else if (!suanzhuComponent.HasMoved && hit.collider.gameObject.layer == LayerMask.NameToLayer("up"))
                            {
                                int index = suanzhuComponent.gameObjects.IndexOf(hit.collider.gameObject);
                                if (index != 1)
                                {
                                    for (int i = 1; i > index; i--)
                                    {
                                        GameObject obj = suanzhuComponent.gameObjects[i];
                                        suanzhu zhuzi = obj.GetComponent<suanzhu>();
                                        if (!zhuzi.HasMoved)
                                        {
                                            SuanzhuMove3(obj, zhuzi);
                                        }
                                    }
                                }
                                SuanzhuMove3(hit.collider.gameObject, suanzhuComponent);
                            }
                            else if (suanzhuComponent.HasMoved && hit.collider.gameObject.layer == LayerMask.NameToLayer("up"))
                            {
                                int index = suanzhuComponent.gameObjects.IndexOf(hit.collider.gameObject);
                                if (index != 0)
                                {
                                    for (int i = 0; i < index; i++)
                                    {
                                        GameObject obj = suanzhuComponent.gameObjects[i];
                                        suanzhu zhuzi = obj.GetComponent<suanzhu>();
                                        if (zhuzi.HasMoved)
                                        {
                                            SuanzhuMove4(obj, zhuzi);
                                        }
                                    }
                                }
                                SuanzhuMove4(hit.collider.gameObject, suanzhuComponent);
                            }
                        }
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    // 清空目标物体
                    break;
            }
        }
    }
}
