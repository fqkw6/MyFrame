// using System;
// using System.Collections.Generic;
// using System.Text;
// public class MsgIDDefine
// {
// 	static Dictionary<int, string> msgid2msgname = new Dictionary<int, string>();
// 	static Dictionary<string, int> msgname2msgid = new Dictionary<string, int>();
// 	static void Initialize()
// 	{
// 		msgid2msgname['b'10001''] = "b'login.req_login'";
// 		msgname2msgid['b'login.req_login''] = b'10001';
// 		msgid2msgname['b'10002''] = "b'login.rsp_login'";
// 		msgname2msgid['b'login.rsp_login''] = b'10002';
// 		msgid2msgname['b'11001''] = "b'login.ntf_logout'";
// 		msgname2msgid['b'login.ntf_logout''] = b'11001';
// 		msgid2msgname['b'30001''] = "b'user.req_create_user'";
// 		msgname2msgid['b'user.req_create_user''] = b'30001';
// 		msgid2msgname['b'30002''] = "b'user.rsp_create_user'";
// 		msgname2msgid['b'user.rsp_create_user''] = b'30002';
// 		msgid2msgname['b'30003''] = "b'user.req_change_name'";
// 		msgname2msgid['b'user.req_change_name''] = b'30003';
// 		msgid2msgname['b'30004''] = "b'user.rsp_change_name'";
// 		msgname2msgid['b'user.rsp_change_name''] = b'30004';
// 		msgid2msgname['b'30001''] = "b'room.req_join_match'";
// 		msgname2msgid['b'room.req_join_match''] = b'30001';
// 		msgid2msgname['b'30002''] = "b'room.rsp_join_match'";
// 		msgname2msgid['b'room.rsp_join_match''] = b'30002';
// 		msgid2msgname['b'30003''] = "b'room.req_cancel_join_match'";
// 		msgname2msgid['b'room.req_cancel_join_match''] = b'30003';
// 		msgid2msgname['b'30004''] = "b'room.rsp_cancel_join_match'";
// 		msgname2msgid['b'room.rsp_cancel_join_match''] = b'30004';
// 		msgid2msgname['b'31001''] = "b'room.ntf_join_match_result'";
// 		msgname2msgid['b'room.ntf_join_match_result''] = b'31001';
// 		msgid2msgname['b'31002''] = "b'room.ntf_join_match_mateinfo'";
// 		msgname2msgid['b'room.ntf_join_match_mateinfo''] = b'31002';
// 		msgid2msgname['b'31003''] = "b'room.ntf_join_match_testt'";
// 		msgname2msgid['b'room.ntf_join_match_testt''] = b'31003';
// 	}
// 	static string GetMsgNameByID(int msgid)
// 	{
// 		string msgname = null;
// 		if (msgid2msgname.TryGetValue(msgid,out msgname))
// 		{
// 			return msgname;
// 		}
// 		return "";
// 	}
// 	static int GetMsgIDByName(string msgname)
// 	{
// 		int msgid = 0;
// 		if (msgname2msgid.TryGetValue(msgname,out msgid))
// 		{
// 			return msgid;
// 		}
// 		return 0;
// 	}
// }
