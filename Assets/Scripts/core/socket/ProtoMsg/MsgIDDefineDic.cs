using System;
using System.Collections.Generic;
using System.Text;
public class MsgIDDefineDic
{
	public const int b'LOGIN_REQ_LOGIN' = b'10001'; 
	public const int b'LOGIN_RSP_LOGIN' = b'10002'; 
	public const int b'LOGIN_NTF_LOGOUT' = b'11001'; 
	public const int b'USER_REQ_CREATE_USER' = b'30001'; 
	public const int b'USER_RSP_CREATE_USER' = b'30002'; 
	public const int b'USER_REQ_CHANGE_NAME' = b'30003'; 
	public const int b'USER_RSP_CHANGE_NAME' = b'30004'; 
	public const int b'ROOM_REQ_JOIN_MATCH' = b'30001'; 
	public const int b'ROOM_RSP_JOIN_MATCH' = b'30002'; 
	public const int b'ROOM_REQ_CANCEL_JOIN_MATCH' = b'30003'; 
	public const int b'ROOM_RSP_CANCEL_JOIN_MATCH' = b'30004'; 
	public const int b'ROOM_NTF_JOIN_MATCH_RESULT' = b'31001'; 
	public const int b'ROOM_NTF_JOIN_MATCH_MATEINFO' = b'31002'; 
	public const int b'ROOM_NTF_JOIN_MATCH_TESTT' = b'31003'; 
}
