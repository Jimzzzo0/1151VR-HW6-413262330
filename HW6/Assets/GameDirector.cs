using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 60.0f; // 
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
    }

    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            // 時間結束後停止產生新物品（停止遊戲）
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 10)
        {
            // 最後 10 秒衝刺期（可依你的關卡設計自行微調參數）
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 4);
        }
        else if (10 <= this.time && this.time < 30)
        {
            // 中後期加速
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (30 <= this.time && this.time < 50)
        {
            // 中期階段
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 2);
        }
        else
        {
            // 50~60 秒新手適應期
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text = this.point.ToString() + " Point";
    }
}