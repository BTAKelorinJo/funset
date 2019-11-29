using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenPunch1 : MonoBehaviour
{
    //インスペクタからいじれる値を設定します


    [SerializeField] Vector3 Punchmove1;
    [SerializeField] Vector3 Punchscale1;
    [SerializeField] Vector3 Punchrotate1;

    [SerializeField] int Punchpower = 1;

    float Punchera = 0.1f;


    // public void 関数名()で、on clickから操作できる自作関数が作れます。

  

    public void PunchMove1()
    {
        // ↓イベント呼び出し連射で変移が上書きされてずれる対策
        transform.DOComplete(true);

        transform.DOPunchPosition(Punchmove1, 0.5f, Punchpower, Punchera);
    }

    public void PunchScale1()
    {
        transform.DOComplete(true);

        transform.DOPunchScale(Punchscale1, 0.5f, Punchpower, Punchera);
    }

    public void PunchRotate1()
    {
        transform.DOComplete(true);

        transform.DOPunchRotation(Punchrotate1, 0.5f, Punchpower, Punchera);
    }


}