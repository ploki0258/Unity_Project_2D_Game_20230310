using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    // �b��ӱM�ץ���ŧi�@��instance(��PlayerCtrl�ܦ����)
    public static PlayerCtrl instance = null;

    [Header("���ʳt��"),Range(1,30)]
    [SerializeField] float speed = 1.5f;
    [Header("�̤j��q")]
    [SerializeField] float hpMax = 100;
    [Header("���")]
    [SerializeField] Image hpBar = null;
    [Header("��q�ƭ�")]
    [SerializeField] Text hpText = null;
    [Header("�ɶ���r����")]
    [SerializeField] Text textTime = null;
    [Header("��ű�")]
    [SerializeField] Slider ��O�� = null;

    Collider2D tempTarget = null;
    bool startTimer = false;
    private Rigidbody2D rig = null;
    private Animator ani = null;

    private void Awake()
    {
        instance = this;    // ����ҵ���ۤv
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
    /// ���Ⲿ�ʡG�ʵe�B½��
    /// </summary>
    private void Move()
    {
        float ws = Input.GetAxisRaw("Vertical");    // ���� -1~1
        float ad = Input.GetAxisRaw("Horizontal");  // ���� -1~1

        Vector2 move = new Vector2(ad * speed, ws * speed);
        rig.velocity = move;           // ���Ⲿ��
        // transform.Translate(move);  // ���Ⲿ��(�ݦb���WTime.deltaTime)

        // ����ʵe
        /*
        if (move != Vector2.zero)
        {
            ani.SetBool("�V�W��", ws > 0);
            ani.SetBool("�V�U��", ws < 0);
            ani.SetBool("�V�k��", ad > 0);
        }
        //½��
        if (move.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        */
    }

    /// <summary>
    /// ��q����
    /// </summary>
    float hp
    {
        get { return hpMax * hpBar.fillAmount; } // Ū��
        set // �g�J
        {
            _hp = value;
            hpBar.fillAmount = value / hpMax;   // �ʤ���
            hpText.text = Mathf.Round(hp) + "/" + hpMax;
            ��O��.value = value / hpMax;
        }
    }
    float _hp = 0f;

    /// <summary>
    /// �ˮ`�޲z��
    /// </summary>
    /// <param name="hurt">�Ҩ����ˮ`�q</param>
    public void TakeDamage(float hurt)
    {
        hp -= hurt;
    }

    /// <summary>
    /// ��s�ɶ�����
    /// </summary>
    private void timer()
    {
        if (tempTarget != null && startTimer == true && hp != 0)
        {
            textTime.text = "�ɶ��G" + Time.time; // �ɶ���r���� = "�ɶ��G" + ���J�����ɶ�(��U���J�����g�L�h�֮ɶ�)
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
