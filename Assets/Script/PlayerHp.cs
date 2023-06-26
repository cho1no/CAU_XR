using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp Instance;
    [SerializeField]
    public int playerHp { get; private set; }
    public Image hpBar;
    public Text hpText;
    public int MaxHp;
    private void Awake()
    {
        Instance = this;
        playerHp = MaxHp;
    }
    private void Update()
    {
            
            hpText.text = playerHp.ToString();
        
    }
    public void SetHp(int i)
    {
        playerHp += i;
        hpBar.fillAmount = (float)playerHp/MaxHp;
        playerHp = Mathf.Clamp(playerHp, 0, MaxHp);
    }
    
}
