using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class Raycast : MonoBehaviour
{
    //Raycast を実行するためのクラス
    private ARRaycastManager m_RaycastManager;
    //Raycast の結果を格納する List
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    //キャラクターの Prefab
    [SerializeField]
    private GameObject characterPrefab;
    void Start()
    {
        //GameObject にアタッチされている RaycastManager を取得
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        //画面がタッチされたら処理を行う
        if (Input.touchCount > 0)
        {
            //画面タッチの情報を取得する
            Touch touch = Input.GetTouch(0);
            //画面タッチの開始時のみ処理を行う
            if (touch.phase == TouchPhase.Began)
            {
                //タッチした方向に Ray を飛ばし、平面との衝突判定を行う
                if (m_RaycastManager.Raycast(
                touch.position,
                hitResults,
                TrackableType.PlaneWithinPolygon
                ))
                {
                    //最初に交差した平面から姿勢を取得して、GameObject を生成する
                    Pose hitPose = hitResults[0].pose;
                    GameObject character = Instantiate(
                    characterPrefab,
                    hitPose.position,
                    hitPose.rotation
                    );
                }
            }
        }
    }
}
