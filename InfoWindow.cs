/*************************************************
	作者: Plane
	邮箱: 1785275942@qq.com	
	功能: 玩家信息窗口

    //=================*=================\\
           教学官网：www.qiqiker.com
           官方微信服务号: qiqikertuts
           Plane老师微信: PlaneZhong
               ~~获取更多教学资讯~~
    \\=================*=================//
*************************************************/

using UnityEngine;
using UnityEngine.UI;

public class InfoWindow : MonoBehaviour {
    public Text txtInfoName;

    EvtSvc evtSvc;
    PlayerInfoData pd;

    void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();

        SetName();

        evtSvc = GameRoot.Instance.GetEvtSvc();
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange, RefreshInfoName);
        evtSvc.AddEvtListener(EvtID.OnTestLog, TestLog);
    }

    void SetName() {
        txtInfoName.text = pd.name;
    }

    void RefreshInfoName(object param1, object param2) {
        SetName();
    }

    void TestLog(object param1, object param2) {
        Debug.Log("InfoWindow Log:" + param1.ToString());
    }

    public void ClickPlayerIcon() {
        GameRoot.Instance.SetSettingWndState();
    }

    void OnDisable() {
        evtSvc.RmvTargetListener(this);
    }
}