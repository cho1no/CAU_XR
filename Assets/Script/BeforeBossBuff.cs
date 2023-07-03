using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBossBuff : MonoBehaviour
{
    public static BeforeBossBuff Instance;
    [SerializeField]
    public int bossBuff { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void SetBuff(int i)
    {
        bossBuff += i;
    }
}
