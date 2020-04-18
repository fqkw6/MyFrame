using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class UILogin : MonoBehaviour
{
    // Start is called before the first frame update
    public string panelname = "panelName";
    private void Awake()
    {
        // panelname = string.Format(gameObject.name, "panel");

    }
    // void Start()
    // {
    //     Debug.LogError("ssss");
    //     //XLuaManager.Instance.SafeDoString("testlua.Debug");
    // }

  

    LuaEnv luaEnv = null;
    // Use this for initialization
    void Start()
    {
        //初始化lua环境  
        luaEnv = new LuaEnv();

        #region   C#调用lua

        luaEnv.DoString("print'hello word'");
        string scriptName = "testlua.lua";
        scriptName = Application.dataPath + "/Scripts/DhlTest/" + scriptName;

        //第二种加载Lua文件  用 require
        luaEnv.DoString(string.Format("require('{0}')", scriptName));
        int a = luaEnv.Global.Get<int>("a");
        Debug.Log("C# 调用lua里面定义的变量" + a);
        //获取定义变量   可以通过luaEnv.Global.Get<>()  就可以在C#中访问XLUA里面的声明的变量
        //         int a = luaEnv.Global.Get<int>("a");
        //         int b = luaEnv.Global.Get<int>("b");
        //         bool c = luaEnv.Global.Get<bool>("c");
        //         string d = luaEnv.Global.Get<string>("d");
        //         Debug.Log("C# 调用lua里面定义的变量" + (a + b) + c + d);

        //         //获取lua 无参方法
        //         LuaFunction funLua1 = luaEnv.Global.Get<LuaFunction>("funLua1");
        //         //调用方法
        //         funLua1.Call();

        //         //调用lua  有参方法
        //         LuaFunction funLua2 = luaEnv.Global.Get<LuaFunction>("funLua2");
        //         funLua2.Call(1, 2);

        #endregion

        luaEnv.DoString("CS.UnityEngine.Debug.Log('C#  hello word hello word')");

    }
}
