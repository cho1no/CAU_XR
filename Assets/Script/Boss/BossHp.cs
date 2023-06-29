 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public static BossHp Instance;
    [SerializeField]
    public int bossHp { get; private set; }
    public Image bosshpBar;
    public Text bosshpText;
    public int bossMaxHp;
    private void Awake()
    {
        Instance = this;
        bossHp = bossMaxHp;
    }
    private void Update()
    {
            
            bosshpText.text = bossHp.ToString();
        
    }
    public void SetHp(int i)
    {
        bossHp += i;
        bosshpBar.fillAmount = (float)bossHp/bossMaxHp;
        bossHp = Mathf.Clamp(bossHp, 0, bossMaxHp);
    }
}
