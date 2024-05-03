using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 剧情对话 : MonoBehaviour
{
    // 对话文本csv格式文件
    public TextAsset chatfile;
    // 玩家UI
    public Image 主角;
    // npc
    public Image npc;
    // 人物名字文本
    public Text 名称文本;
    // 对话内容文本
    public Text 对话文本;
    // 用于更新图片
    public List<Sprite> images = new List<Sprite>();
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();

    //当前对话索引值
    public int 对话索引;
    //对话文本 按行分割
    public string[] chatrows;
    
    public Button 继续键;
    //选项按钮预制体
    public Button 选项;
    //选项的父节点 用于排序
    public Transform 选项组;
    public Transform 剧情;
    public Button 消息;

    public Transform 摇杆;
    public Transform 跳跃;

    private void Awake()
    {
        imageDic["你"] = images[0];
        imageDic["智叟"] = images[1];
    }
    void Start()
    {
        摇杆.gameObject.SetActive(true);
        跳跃.gameObject.SetActive(true);

        ReadText(chatfile);
    }

    void Update()
    {
        //UpdateText("智叟", "你好");
        //UpdateImage("智叟", "左");
    }

    // 更新文本内容
    public void UpdateText(string _name, string _text)
    {
        名称文本.text = _name;
        对话文本.text = _text;
    }

    // 更新图片内容
    public void UpdateImage(string _name, string _position)
    {
        if (_position == "左")
        {
            主角.sprite = imageDic[_name];
        }
        else if (_position == "右")
        {
            npc.sprite = imageDic[_name];
        }
    }

    //读取csv文件
    public void ReadText(TextAsset _textAsset)
    {
        string[] rows = _textAsset.text.Split('\n');
        chatrows = new string[rows.Length];
        for(int i = 0; i < rows.Length; i++)
        {
            chatrows[i] = rows[i].Trim();
        }
        Debug.Log("读取成功");
        显示对话();
    }

    public void 显示对话()
    {
        for(int i = 0;i <chatrows.Length; i++)
        {
            string[] cells = chatrows[i].Split(',');
            if (cells[0] == "#" && int.Parse(cells[1]) == 对话索引)
            {
                继续键.gameObject.SetActive(true);
                选项.gameObject.SetActive(false);
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

                对话索引 = int.Parse(cells[5]);
                break;
            }
            
            else if (cells[0] == "$" && int.Parse(cells[1]) == 对话索引)
            {
                Debug.Log("读取选项");
                选项.gameObject.SetActive(true);
                继续键.gameObject.SetActive(false);
                生成选项(i);
                选项.gameObject.SetActive(false);
            }

            else if (cells[0] == "END" && int.Parse(cells[1]) == 对话索引)
            {
                Debug.Log("剧情结束");
                剧情.gameObject.SetActive(false);
                消息.gameObject.SetActive(true);
                摇杆.gameObject.SetActive(true);
                跳跃.gameObject.SetActive(true);

            }
        }
    }


    public void OnClickNext()
    {
        显示对话();
    }

    public void 生成选项(int _index)
    {
        string[] cells = chatrows[_index].Split(',');
        if(cells[0] == "$")
        {
            UnityEngine.UI.Button button = Instantiate(选项, 选项组);

            // 绑定按钮事件
            button.GetComponentInChildren<Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener
            (
                delegate
                {
                    点击选项(int.Parse(cells[5]));
                }
            );            
             
            生成选项(_index + 1);
        }
    }


    public void 点击选项(int _id)
    {
        对话索引 = _id;
        显示对话();
        for(int i = 0;i < 选项组.childCount; i++)
        {
            Destroy(选项组.GetChild(i).gameObject);
        }
    }
}
