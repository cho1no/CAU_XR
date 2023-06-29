using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMP : MonoBehaviour
{
    public static PlayerMP Instance;
    [SerializeField]
    public int playerMp0 { get; private set; }
    public int playerMp1 { get; private set; }
    public Image[] MpBar;
    public Text[] mpText;
    public int[] MaxMp;
    private void Awake()
    {
        Instance = this;
        playerMp0 = MaxMp[0];
        playerMp1 = MaxMp[1];
    }
    private void Update()
    {

        mpText[0].text = playerMp0.ToString();
        mpText[1].text = playerMp1.ToString();

    }
    public void SetMp0(int i)
    {
        playerMp0 += i;
        MpBar[0].fillAmount = (float)playerMp0 / MaxMp[0];
        playerMp0 = Mathf.Clamp(playerMp0, 0, MaxMp[0]);
    }
    public void SetMp1(int i)
    {
        playerMp1 += i;
        MpBar[1].fillAmount = (float)playerMp1 / MaxMp[1];
        playerMp1 = Mathf.Clamp(playerMp1, 0, MaxMp[1]);
    }
}
