using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTransit1 : MonoBehaviour
{
    //インスペクタからいじれる値を設定します
    [SerializeField] Vector3 transmove1;
    [SerializeField] Vector3 transmove2;

    [SerializeField] Vector3 transscale1;
    [SerializeField] Vector3 transscale2;

    [SerializeField] Vector3 transrotate1;
    [SerializeField] Vector3 transrotate2;

    [SerializeField] float time1 = 0.5f;
    [SerializeField] float time2 = 0.5f;


    // public void 関数名()で、on clickから操作できる自作関数が作れます。

    public void Move1()
    {
        // ↓イベント呼び出し連射で変移が上書きされてずれる対策
        transform.DOComplete(true);

        transform.DOLocalMove(transmove1, time1).SetRelative();
    }

    public void Scale1()
    {
        transform.DOComplete(true);

        transform.DOScale(transscale1, time1);
    }

    public void Rotate1()
    {
        transform.DOComplete(true);

        transform.DOLocalRotate(transrotate1, time1).SetRelative();
    }

    public void Move2()
    {
        transform.DOComplete(true);

        transform.DOLocalMove(transmove2, time2).SetRelative();
    }

    public void Scale2()
    {
        transform.DOComplete(true);

        transform.DOScale(transscale2, time2);
    }

    public void Rotate2()
    {
        transform.DOComplete(true);

        transform.DOLocalRotate(transrotate2, time2).SetRelative();
    }

}