/*************************************************
	作者: Plane
	邮箱: 1785275942@qq.com	
	功能: 消息事件服务

    //=================*=================\\
           教学官网：www.qiqiker.com
           官方微信服务号: qiqikertuts
           Plane老师微信: PlaneZhong
               ~~获取更多教学资讯~~
    \\=================*=================//
*************************************************/

using System;
using UnityEngine;

public enum EvtID {
    None = 0,
    /// <summary>
    /// 当玩家改名时
    /// </summary>
    OnPlayerNameChange,

    /// <summary>
    /// 打印测试日志
    /// </summary>
    OnTestLog,
}

public class EvtSvc : MonoBehaviour {
    PEMsger<EvtID> msger = new PEMsger<EvtID>();
    private void Awake() {
        msger.MsgerInit();
    }
    private void Update() {
        msger.MsgerTick();
    }
    private void OnDestroy() {
        msger.MsgerUnInit();
    }

    public void AddEvtListener(EvtID evt, Action<object, object> cb) {
        msger.AddMsgHandler(evt, cb);
    }
    public void RmvEvtListener(EvtID evt) {
        msger.RmvHandlerByMsgID(evt);
    }
    public void RmvTargetListener(object target) {
        msger.RmvHandlerByTarget(target);
    }

    public void SendEvt(EvtID evt, object param1 = null, object param2 = null) {
        msger.InvokeMsgHandler(evt, param1, param2);
    }
    public void SendEvtImmediately(EvtID evt, object param1 = null, object param2 = null) {
        msger.InvokeMsgHandlerImmediately(evt, param1, param2);
    }
}