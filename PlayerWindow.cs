/*************************************************
	作者: Plane
	邮箱: 1785275942@qq.com	
	功能: 玩家展示界面

    //=================*=================\\
           教学官网：www.qiqiker.com
           官方微信服务号: qiqikertuts
           Plane老师微信: PlaneZhong
               ~~获取更多教学资讯~~
    \\=================*=================//
*************************************************/

using UnityEngine;
using UnityEngine.UI;

public class PlayerWindow : MonoBehaviour {
    public Text txtPlayerName;

    EvtSvc evtSvc;
    PlayerInfoData pd;

    void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();

        SetName();

        evtSvc = GameRoot.Instance.GetEvtSvc();
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange, RefreshPlayerName);
        evtSvc.AddEvtListener(EvtID.OnTestLog, TestLog);
    }

    void SetName() {
        txtPlayerName.text = pd.name;
    }

    void RefreshPlayerName(object param1, object param2) {
        SetName();
    }

    void TestLog(object param1, object param2) {
        Debug.Log("PlayerWindow Log:" + param1.ToString());
    }

    void OnDisable() {
        evtSvc.RmvTargetListener(this);
    }
}