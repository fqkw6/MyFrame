// using System;
// using System.Collections.Generic;
// using System.Text;
// public class MsgIDDef
// {
// 	private Dictionary<int, Type> sc_msg_dic = new Dictionary<int, Type>();
// 	private static MsgIDDef instance;
// 	public static MsgIDDef Instance()
// 	{
// 		if (null == instance)
// 		{
// 			instance = new MsgIDDef();
// 		}
// 		return instance;
// 	}
// 	private MsgIDDef()
// 	{
// 		sc_msg_dic.Add(b'10001',typeof(b'login.req_login'));
// 		sc_msg_dic.Add(b'10002',typeof(b'login.rsp_login'));
// 		sc_msg_dic.Add(b'11001',typeof(b'login.ntf_logout'));
// 		sc_msg_dic.Add(b'30001',typeof(b'user.req_create_user'));
// 		sc_msg_dic.Add(b'30002',typeof(b'user.rsp_create_user'));
// 		sc_msg_dic.Add(b'30003',typeof(b'user.req_change_name'));
// 		sc_msg_dic.Add(b'30004',typeof(b'user.rsp_change_name'));
// 		sc_msg_dic.Add(b'30001',typeof(b'room.req_join_match'));
// 		sc_msg_dic.Add(b'30002',typeof(b'room.rsp_join_match'));
// 		sc_msg_dic.Add(b'30003',typeof(b'room.req_cancel_join_match'));
// 		sc_msg_dic.Add(b'30004',typeof(b'room.rsp_cancel_join_match'));
// 		sc_msg_dic.Add(b'31001',typeof(b'room.ntf_join_match_result'));
// 		sc_msg_dic.Add(b'31002',typeof(b'room.ntf_join_match_mateinfo'));
// 		sc_msg_dic.Add(b'31003',typeof(b'room.ntf_join_match_testt'));
// 	}
// 	public Type GetMsgType(int msgID)
// 	{
// 		Type msgType = null;
// 		sc_msg_dic.TryGetValue(msgID, out msgType);
// 		if (msgType==null)
// 		{
// 			return null;
// 		}
// 		return msgType;
// 	}
// }
