/*************************************************
	作者: Plane
	邮箱: 1785275942@qq.com	
	功能: 设置界面

    //=================*=================\\
           教学官网：www.qiqiker.com
           官方微信服务号: qiqikertuts
           Plane老师微信: PlaneZhong
               ~~获取更多教学资讯~~
    \\=================*=================//
*************************************************/

using UnityEngine;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour {
    public Text txtSetName;

    EvtSvc evtSvc;
    PlayerInfoData pd;

    void OnEnable() {
        pd = GameRoot.Instance.GetPlayerInfoData();

        SetName();

        evtSvc = GameRoot.Instance.GetEvtSvc();
        evtSvc.AddEvtListener(EvtID.OnPlayerNameChange, RefreshSettingName);
        evtSvc.AddEvtListener(EvtID.OnTestLog, TestLog);
    }


    void SetName() {
        txtSetName.text = pd.name;
    }

    void RefreshSettingName(object param1, object param2) {
        SetName();
    }

    void TestLog(object param1, object param2) {
        Debug.Log("SettingWindow Log:" + param1.ToString());
    }

    public void ClickCloseBtn() {
        GameRoot.Instance.SetSettingWndState(false);
    }

    public void ClickRenameBtn() {
        pd.name = "解放西路小旋风" + Random.Range(1, 100);
        evtSvc.SendEvt(EvtID.OnPlayerNameChange);
    }

    void OnDisable() {
        evtSvc.RmvTargetListener(this);
    }
}