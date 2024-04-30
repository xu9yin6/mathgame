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
    private void Awake()
    {
        imageDic["你"] = images[0];
        imageDic["智叟"] = images[1];
    }
    void Start()
    {
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
            if (cells.Length >= 6 && cells[0] == "#" && int.TryParse(cells[1], out int index))
            {
                选项.gameObject.SetActive(false);
                if (index == 对话索引)
                {
                    UpdateText(cells[2], cells[4]);
                    UpdateImage(cells[2], cells[3]);

                    if (int.TryParse(cells[5], out int nextIndex))
                    {
                        对话索引 = nextIndex;
                    }
                    else
                    {
                        Debug.LogError("无法解析下一个对话索引：" + cells[5]);
                    }
                    继续键.gameObject.SetActive(true);
                    break;
                }
            }
            else if (cells.Length >= 6 && int.TryParse(cells[1], out int 对话索引) && cells[0] == "$")
            {
                Debug.Log("读取选项");
                选项.gameObject.SetActive(true);
                继续键.gameObject.SetActive(false);
                生成选项(i);
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
            //Destory(选项组.GetChild(i).gameObject);
            选项.gameObject.SetActive(false);
        }
    }
}
