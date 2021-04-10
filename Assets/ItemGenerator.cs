using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab
    public GameObject carPrefab;

    //coinPrefab
    public GameObject coinPrefab;

    //cornPrefab
    public GameObject conePrefab;

    //スタート地点
    private int startPos = 80;

    //ゴール地点
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // 次のオブジェクトを表示する場所
    private int nextPoint;

    // オブジェクトの表示範囲
    private int viewSize = 40;

    // オブジェクトの表示間隔
    private int objectSpan = 15;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        this.nextPoint = 0;

        for (int i = 0; i < viewSize; i += objectSpan)
        {
            createGameObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Unityちゃんの位置が、
        if (unitychan.transform.position.z > this.nextPoint)
        {
            createGameObject();
        }
    }

    void createGameObject()
    {

        // 次の表示箇所を更新する
        this.nextPoint += this.objectSpan;

        // 表示位置を計算
        int pos = this.startPos + this.nextPoint;

        // ゴールの位置を超える場合、表示しない。
        if (pos > goalPos)
        {
            return;
        }

        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        
        // 乱数の値に応じたオブジェクトを配置する。
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, pos);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);

                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);

                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, pos + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, pos + offsetZ);
                }
            }
        }
    }
}