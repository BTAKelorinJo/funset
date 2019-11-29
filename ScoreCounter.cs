using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreCounter : MonoBehaviour {

    // スコアカウントの初期設定

    public int score;
    public Text scoretext;
    float tweenadjust = 1.0f;


    //トゥイーン用設定　フォントサイス、が可変する

    [SerializeField, Range(1f, 100f)]
    int tweenfontsize1 = 16;

    [SerializeField, Range(1f, 100f)]
    int tweenfontsize2 = 20;

    [SerializeField]
    Color tweencolor1;

    [SerializeField]
    Color tweencolor2;

    [SerializeField, Range(0.1f, 5f)]
    float tweenspeed = 0.5f;

    [SerializeField]
    float ptsboader = 10f;

    
    // Use this for initialization
    void Start () {

        //でたらめな数値が設定されてたらここで判定して、修正する

        if (ptsboader < 1) { ptsboader = 1f; };
	}

    // スコアをトゥイーンしながら加算する関数 引数ptsは加算する得点
    public void addscoretween(int pts)
    {


        //   トゥイーン補正判定 ptsの大きさに比例した変位をさせるが、　変位上限ptsboaderを超えたら違う挙動にする

        if (pts < ptsboader) { tweenadjust = pts / ptsboader; } else { tweenadjust = 1f; };

 //       Debug.Log(tweenadjust);

        if (tweenadjust < 0.1f) { tweenadjust = 0.1f; };



        //　スコアがトゥイーンで加算する
 
            DOTween.To(() => score, (n) => score = n, score + pts, tweenspeed * tweenadjust).OnUpdate(() => scoretext.text = score.ToString("#,0"));



        //   フォントサイズが増えて戻るシーケンス ptsの大きさに比例する　変位上限はptsboader
        //　微増の場合は分岐

  //      if (tweenadjust >= 1f)
   //     {
   //         Sequence seqsize = DOTween.Sequence();
  //
   //         seqsize.Append(DOTween.To(() => scoretext.fontSize, (n) => scoretext.fontSize = n, tweenfontsize2, tweenspeed * tweenadjust / 2f));
   //         seqsize.Append(
   //             DOTween.To(() => scoretext.fontSize, (n) => scoretext.fontSize = n, tweenfontsize1, tweenspeed * tweenadjust / 2f)
   //             );
   //     }
   //     else
  //      {
            Sequence seqsize = DOTween.Sequence();

            seqsize.Append(DOTween.To(() => scoretext.fontSize, (n) => scoretext.fontSize = n, tweenfontsize1 + (int)((tweenfontsize2- tweenfontsize1) * tweenadjust), tweenspeed * tweenadjust / 2f));
            seqsize.Append(
                DOTween.To(() => scoretext.fontSize, (n) => scoretext.fontSize = n, tweenfontsize1, tweenspeed * tweenadjust / 2f)
                );
   //     }

   //     Debug.Log(tweenfontsize1 + (int)((tweenfontsize2 - tweenfontsize1) * tweenadjust));


        // テキストカラーが変位するシーケンス
        //　微増の場合は色変化なし

        if (tweenadjust >= 1f)
        {
            Sequence seqcolor = DOTween.Sequence();

            seqcolor.Append(scoretext.DOColor(tweencolor2, tweenspeed * tweenadjust / 2f));
            seqcolor.Append(
                scoretext.DOColor(tweencolor1, tweenspeed * tweenadjust / 2f)
                );
        }


 



    }
}
