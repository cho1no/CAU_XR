using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossGuard : MonoBehaviour
{
    public static BossGuard Instance;
    [SerializeField]
    public int bossGuard { get; private set; }
    public Image guardBar;
    public Text guardText;
    public int MaxGuard;
    private void Awake()
    {
        Instance = this;
        bossGuard = MaxGuard;
    }
    private void Update()
    {
            
            guardText.text = bossGuard.ToString();
        
    }
    public void SetGuard(int i)
    {
        bossGuard += i;
        guardBar.fillAmount = (float)bossGuard/MaxGuard;
        bossGuard = Mathf.Clamp(bossGuard, 0, MaxGuard);
    }
}
