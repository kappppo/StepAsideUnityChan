using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // カメラの位置
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // 表示範囲を超えたオブジェクトを破棄
        if (this.transform.position.z < this.camera.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }

}
