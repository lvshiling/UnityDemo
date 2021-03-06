﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    /// <summary>
    /// 幸运转盘指针父对象的Transform
    /// </summary>
    private Transform roolPointer;

    /// <summary>
    /// 初始旋转速度
    /// </summary>
    private float initSpeed;

    /// <summary>
    /// 速度变化值
    /// </summary>
    private float changeSpeed = 0.5f;

    /// <summary>
    /// 转盘是否暂停
    /// </summary>
    private bool isPause = true;

    /// <summary>
    /// button事件，控制指针
    /// </summary>
    private Button button;

    void Awake()
    {
        //获取幸运转盘指针父对象的Transform
        roolPointer = GetComponent<Transform>();

        //获取button按钮
        button = transform.parent.Find("Button").GetComponent<Button>();
    }

    /// <summary>
    /// 开始抽奖，注册OnClick事件
    /// </summary>
    void OnEnable()
    {
        //清空button注册事件
        button.onClick.RemoveAllListeners();
        //注册OnClick事件
        button.onClick.AddListener(OnButtonClick);
    }

    /// <summary>
    /// 点击事件
    /// </summary>
    public void OnButtonClick()
    {
        Debug.Log("cccc");
        if (isPause)
        {
            //随机生成一个初始速度
            initSpeed = Random.Range(100, 500);

            //开始旋转
            isPause = false;
        }
    }

    void Update()
    {
        if (!isPause)
        {
            //转动转盘(-1为顺时针,1为逆时针)
            roolPointer.Rotate(new Vector3(0, 0, -1) * initSpeed * Time.deltaTime);

            //让转动的速度缓缓降低
            initSpeed -= changeSpeed;

            //当转动的速度为0时转盘停止转动
            if (initSpeed <= 0)
            {
                //转动停止
                isPause = true;
            }
        }
    }
}
