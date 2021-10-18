/*************************************************
	作者: Plane
	邮箱: 1785275942@qq.com	
	功能: 游戏启动根节点

    //=================*=================\\
           教学官网：www.qiqiker.com
           官方微信服务号: qiqikertuts
           Plane老师微信: PlaneZhong
               ~~获取更多教学资讯~~
    \\=================*=================//
*************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour {
    public static GameRoot Instance;

    public InfoWindow infoWindow;
    public PlayerWindow playerWindow;
    public SettingWindow setWindow;

    EvtSvc evtSvc;
    PlayerInfoData pd;

    void Awake() {
        Instance = this;

        evtSvc = GetComponent<EvtSvc>();

        pd = new PlayerInfoData {
            name = "宝安大道小旋风",
            level = 666,
        };
    }

    private void Start() {
        SetInfoWndState();
        SetPlayerWndState();
        SetSettingWndState(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            evtSvc.SendEvt(EvtID.OnTestLog, "www.qiqiker.com");
        }
    }

    public EvtSvc GetEvtSvc() {
        return evtSvc;
    }

    public PlayerInfoData GetPlayerInfoData() {
        return pd;
    }

    public void SetInfoWndState(bool state = true) {
        infoWindow.gameObject.SetActive(state);
    }
    public void SetPlayerWndState(bool state = true) {
        playerWindow.gameObject.SetActive(state);
    }
    public void SetSettingWndState(bool state = true) {
        setWindow.gameObject.SetActive(state);
    }
}

public class PlayerInfoData {
    public string name;
    public int level;
}
