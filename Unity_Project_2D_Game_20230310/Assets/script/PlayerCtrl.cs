﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [Header("移動速度"), Range(1, 30)]
    [SerializeField] float speed = 1.5f;
    [Header("最大血量")]
    [SerializeField] float hpMax = 100;
    [Header("血條")]
    [SerializeField] Image hpBar = null;
    [Header("血量數值")]
    [SerializeField] Text hpText = null;
    [Header("時間文字介面")]
    [SerializeField] Text textTime = null;
    [Header("體溫條")]
    [SerializeField] Slider 體力條 = null;

    Collider2D tempTarget = null;
    bool startTimer = false;
    private Rigidbody2D rig = null;
    private Animator ani = null;

    // 在整個專案全域宣告一個instance(讓PlayerCtrl變成單例)
    public static PlayerCtrl instance = null;

    private void Awake()
    {
        instance = this;    // 讓單例等於自己
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        hp = hpMax;
    }

    private void Update()
    {
        Move();
        timer();
    }

    /// <summary>
    /// 移動方法：角色移動、動畫與翻轉
    /// </summary>
    private void Move()
    {
        float ws = Input.GetAxisRaw("Vertical");    // 垂直 -1~1
        float ad = Input.GetAxisRaw("Horizontal");  // 水平 -1~1

        Vector2 move = new Vector2(ad * speed, ws * speed);
        rig.velocity = move;           // 角色移動
        /*transform.Translate(move);  // 角色移動(需在乘上Time.deltaTime)*/

        // 角色動畫
        ani.SetBool("runUp", ws > 0);
        ani.SetBool("runDown", ws < 0);
        ani.SetBool("runRight", ad != 0);

        // 角色翻轉
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, 1);  // 左翻
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);  // 右翻
        }
        /*
        if (move != Vector2.zero && move.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);  // 左翻
        }
        */
    }

    /// <summary>
    /// 血量控制
    /// </summary>
    float hp
    {
        get { return hpMax * hpBar.fillAmount; } // 讀取
        set // 寫入
        {
            _hp = value;
            hpBar.fillAmount = value / hpMax;   // 百分比
            hpText.text = Mathf.Round(hp) + "/" + hpMax;
            體力條.value = value / hpMax;
        }
    }
    float _hp = 0f;

    /// <summary>
    /// 傷害管理器
    /// </summary>
    /// <param name="hurt">所受的傷害量</param>
    public void TakeDamage(float hurt)
    {
        hp -= hurt;
    }

    /// <summary>
    /// 更新時間介面
    /// </summary>
    private void timer()
    {
        if (tempTarget != null && startTimer == true && hp != 0)
        {
            textTime.text = "時間：" + Time.time; // 時間文字介面 = "時間：" + 載入場景時間(當下載入場景經過多少時間)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            tempTarget = collision;
        }
        startTimer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            tempTarget = null;
        }
        startTimer = false;
    }
}
