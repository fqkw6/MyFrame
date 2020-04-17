/*
Copyright (c) 2015-2017 topameng(topameng@qq.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
    public class LuaException : Exception
    {
        public static Exception luaStack = null;
        public static string projectFolder = null;
        public static int InstantiateCount = 0;
        public static int SendMsgCount = 0;
        public static IntPtr L = IntPtr.Zero;

        public override string StackTrace
        {
            get
            {
                return _stack;
            }
        }

        protected string _stack = string.Empty;

        public LuaException(string msg, Exception e = null, int skip = 1)
            //: base(msg) //这是原始代码
            : base(FillExceptionMsgPath(msg))//这里是修改代码，在抛出异常时把msg中的fileName转换成了文件的绝对路径,主要为在unity console双击时提供绝对路径
        {
            if (e != null)
            {
                if (e is LuaException)
                {
                    _stack = e.StackTrace;
                }
                else
                {
                    StackTrace trace = new StackTrace(e, true);
                    StringBuilder sb = new StringBuilder();
                    ExtractFormattedStackTrace(trace, sb);
                    StackTrace self = new StackTrace(skip, true);
                    ExtractFormattedStackTrace(self, sb, trace);
                    _stack = sb.ToString();
                }
            }
            else
            {
                StackTrace self = new StackTrace(skip, true);
                StringBuilder sb = new StringBuilder();
                ExtractFormattedStackTrace(self, sb);
                _stack = sb.ToString();
            }
        }

        private static string FillExceptionMsgPath(string msg)
        {
#if UNITY_EDITOR

            //我这里解析时的错误log格式是
            /*
            ScriptsFromFile.lua:22: attempt to perform arithmetic on local 'luaClass1'(a table value)
            stack traceback:
	            ScriptsFromFile.lua:22: in main chunk

            请使用者根据自己的log格式去修改这里的解析,经过下面处理后会变成
            X:/tolua-master/Assets/ToLua/Examples/02_ScriptsFromFile/ScriptsFromFile.lua:22: attempt to perform arithmetic on local 'luaClass1' (a table value)
            stack traceback:
	            ScriptsFromFile.lua:22: in main chunk

            同时LogLocation也需要修改解析。
            */


            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(msg, "(.*?):\\d+");
            if (match.Success)
            {
                int index = match.Groups[1].Index;
                string msg1 = msg.Substring(index, match.Groups[1].Length);
                string msg2 = msg.Substring(index + match.Groups[1].Length);
                string fullPath = "";//LuaFileUtils.Instance.FindFile(msg1);
                return fullPath + msg2;
            }
            return msg;
#else
            return msg;
#endif
        }

        public static Exception GetLastError()
        {
            Exception last = luaStack;
            luaStack = null;
            return last;
        }

        public static void ExtractFormattedStackTrace(StackTrace trace, StringBuilder sb, StackTrace skip = null)
        {
            int begin = 0;

            if (skip != null && skip.FrameCount > 0)
            {
                MethodBase m0 = skip.GetFrame(skip.FrameCount - 1).GetMethod();

                for (int i = 0; i < trace.FrameCount; i++)
                {
                    StackFrame frame = trace.GetFrame(i);
                    MethodBase method = frame.GetMethod();

                    if (method == m0)
                    {
                        begin = i + 1;
                        break;
                    }
                }

                sb.AppendLine();
            }

            for (int i = begin; i < trace.FrameCount; i++)
            {
                StackFrame frame = trace.GetFrame(i);
                MethodBase method = frame.GetMethod();

                if (method == null || method.DeclaringType == null)
                {
                    continue;
                }

                Type declaringType = method.DeclaringType;
                string str = declaringType.Namespace;

                if ((InstantiateCount == 0 && declaringType == typeof(UnityEngine.Object) && method.Name == "Instantiate") //(method.Name == "Internal_CloneSingle"
                    || (SendMsgCount == 0 && declaringType == typeof(GameObject) && method.Name == "SendMessage"))
                {
                    break;
                }

                if ((str != null) && (str.Length != 0))
                {
                    sb.Append(str);
                    sb.Append(".");
                }

                sb.Append(declaringType.Name);
                sb.Append(":");
                sb.Append(method.Name);
                sb.Append("(");
                int index = 0;
                ParameterInfo[] parameters = method.GetParameters();
                bool flag = true;

                while (index < parameters.Length)
                {
                    if (!flag)
                    {
                        sb.Append(", ");
                    }
                    else
                    {
                        flag = false;
                    }

                    sb.Append(parameters[index].ParameterType.Name);
                    index++;
                }

                sb.Append(")");
                string fileName = frame.GetFileName();

                if (fileName != null)
                {
                    fileName = fileName.Replace('\\', '/');
                    sb.Append(" (at ");

                    if (fileName.StartsWith(projectFolder))
                    {
                        fileName = fileName.Substring(projectFolder.Length, fileName.Length - projectFolder.Length);
                    }

                    sb.Append(fileName);
                    sb.Append(":");
                    sb.Append(frame.GetFileLineNumber().ToString());
                    sb.Append(")");
                }

                if (i != trace.FrameCount - 1)
                {
                    sb.Append("\n");
                }
            }
        }

        public static void Init(IntPtr L0)
        {
            L = L0;
            Type type = typeof(StackTraceUtility);
            FieldInfo field = type.GetField("projectFolder", BindingFlags.Static | BindingFlags.GetField | BindingFlags.NonPublic);
            LuaException.projectFolder = (string)field.GetValue(null);
            projectFolder = projectFolder.Replace('\\', '/');
#if DEVELOPER
            Debugger.Log("projectFolder is {0}", projectFolder);
#endif
        }
    }
}