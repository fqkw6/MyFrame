#! python3
#  暂时不用了
import sys
import os
# 第一次先配置正确路径
cppmsg_dir = "F:/MyFrame/ProtoToCS/ProtoGen/proto/cppmsg"
luamsg_dir = "F:/MyFrame/ProtoToCS/ProtoGen/proto/luamsg"
msgid_conf = "F:/MyFrame/ProtoToCS/ProtoGen/proto/msgid.conf"

target_dir = "../../../../Assets/Scripts/core/socket/protocol/"
curpath = os.path.dirname(os.path.abspath(sys.argv[0]))
print("../")


def test(file):
    dd = open(file, "rb+")
    for line in dd.readlines():
        line = line.strip().rstrip()


test(msgid_conf)


def compile_proto(proto_dir, target_dir):
    files = os.listdir(proto_dir)
    for f in files:
        if not f.endswith('.proto'):
            continue
        target_file = f.replace(".proto", ".cs")
        os.system(".\ProtoGen\protogen.exe -w:" + proto_dir +
                  " -i:" + f + " -o:" + target_dir + target_file)


compile_proto(cppmsg_dir, target_dir)
compile_proto(luamsg_dir, target_dir)


class MsgInfo(object):
    def __init__(self, msgid, msgname, comment):
        self.msgid = msgid
        self.msgname = msgname
        self.comment = comment

    msgid = ""
    msgname = ""
    comment = ""


def ParseMsgIDDefine(fs, msgidList):
    fs.writelines("using System;")
    fs.writelines("using System.Collections.Generic;")
    fs.writelines("using System.Text;")
    fs.writelines("public class MsgIDDefine")
    fs.writelines("{")
    fs.writelines(
        "\tstatic Dictionary<int, string> msgid2msgname = new Dictionary<int, string>();")
    fs.writelines(
        "\tstatic Dictionary<string, int> msgname2msgid = new Dictionary<string, int>();")
    fs.writelines("\tstatic void Initialize()")
    fs.writelines("\t{")

    for _msgDef in msgidList:
        fs.writelines("\t\tmsgid2msgname[\'%s\'] = \"%s\";" % (
            _msgDef.msgid, _msgDef.msgname))
        fs.writelines("\t\tmsgname2msgid['%s'] = %s;" % (
            _msgDef.msgname, _msgDef.msgid))
    fs.writelines("\t}")
    fs.writelines("\tstatic string GetMsgNameByID(int msgid)")
    fs.writelines("\t{")
    fs.writelines("\t\tstring msgname = null;")
    fs.writelines("\t\tif (msgid2msgname.TryGetValue(msgid,out msgname))")
    fs.writelines("\t\t{")
    fs.writelines("\t\t\treturn msgname;")
    fs.writelines("\t\t}")
    fs.writelines("\t\treturn \"\";")
    fs.writelines("\t}")

    fs.writelines("\tstatic int GetMsgIDByName(string msgname)")
    fs.writelines("\t{")
    fs.writelines("\t\tint msgid = 0;")
    fs.writelines("\t\tif (msgname2msgid.TryGetValue(msgname,out msgid))")
    fs.writelines("\t\t{")
    fs.writelines("\t\t\treturn msgid;")
    fs.writelines("\t\t}")
    fs.writelines("\t\treturn 0;")
    fs.writelines("\t}")
    fs.writelines("}")
    fs.flush()

    fs.close()


def ParseMsgIDDef(fs, msgidList):
    fs.writelines("using System;")
    fs.writelines("using System.Collections.Generic;")
    fs.writelines("using System.Text;")
    fs.writelines("public class MsgIDDef")
    fs.writelines("{")

    fs.writelines(
        "\tprivate Dictionary<int, Type> sc_msg_dic = new Dictionary<int, Type>();")
    fs.writelines("\tprivate static MsgIDDef instance;")
    fs.writelines("\tpublic static MsgIDDef Instance()")

    fs.writelines("\t{")

    fs.writelines("\t\tif (null == instance)")
    fs.writelines("\t\t{")
    fs.writelines("\t\t\tinstance = new MsgIDDef();")
    fs.writelines("\t\t}")
    fs.writelines("\t\treturn instance;")
    fs.writelines("\t}")

    fs.writelines("\tprivate MsgIDDef()")
    fs.writelines("\t{")
    for _msgDef in msgidList:
        tmpMsgName = _msgDef.msgname
        fs.writelines("\t\tsc_msg_dic.Add(%s,typeof(%s));" %
                      (_msgDef.msgid, tmpMsgName))

    fs.writelines("\t}")
    fs.writelines("\tpublic Type GetMsgType(int msgID)")
    fs.writelines("\t{")
    fs.writelines("\t\tType msgType = null;")
    fs.writelines("\t\tsc_msg_dic.TryGetValue(msgID, out msgType);")
    fs.writelines("\t\tif (msgType==null)")
    fs.writelines("\t\t{")
    fs.writelines("\t\t\treturn null;")
    fs.writelines("\t\t}")
    fs.writelines("\t\treturn msgType;")
    fs.writelines("\t}")
    fs.writelines("}")

    fs.flush()
    fs.close()


def ParseMsgIDDefineDic(fs, msgidList):
    fs.writelines("using System;")
    fs.writelines("using System.Collections.Generic;")
    fs.writelines("using System.Text;")
    fs.writelines("public class MsgIDDefineDic")
    fs.writelines("{")

    for _msgDef in msgidList:
        fs.writelines("\tpublic const int %s = %s; %s" % (
            _msgDef.msgname.upper().replace(str.encode('.'), str.encode('_')), _msgDef.msgid, _msgDef.comment))

    fs.writelines("}")
    fs.flush()
    fs.close()


def parse_msgfile(msgid_conf__P):
    msg_info_list = []
    msg_file = open(msgid_conf__P, 'rb+')
    for line in msg_file.readlines():
        line = line.strip().rstrip()

        if not len(line) or line.startswith(str.encode('#')):
            continue
        array_info = line.split(str.encode('='))
        msgid = array_info[0].strip().rstrip()  # MSGID

        if int(msgid) < 10000:  # server internal msg
            continue

        array_info = array_info[1].split(str.encode(','))  # MSGNAME
        msgname = array_info[0].strip().rstrip()

        array_info = array_info[1].split(str.encode('#'))
        comment = ""
        if len(array_info) > 1:
            comment = "//" + array_info[1].strip().rstrip()
        msg_info_list.append(MsgInfo(msgid, msgname, comment))

    return msg_info_list


class WrapFile:
    fs = None

    def __init__(self, real_file):
        self.fs = real_file

    def writelines(self, s):
        self.fs.write(s + "\n")

    def flush(self):
        self.fs.flush()

    def close(self):
        self.fs.close()


l = parse_msgfile(msgid_conf)

targetMsgIDPath = "F:/MyFrame/Assets/Scripts/core/socket/ProtoMsg/MsgIDDefineDic.cs"
targetCSPath = "F:/MyFrame/Assets/Scripts/core/socket/ProtoMsg/MsgIDDefine.cs"
targetCSPath2 = "F:/MyFrame/Assets/Scripts/core/socket/ProtoMsg/MsgIDDef.cs"
# 注释掉：tod
# f = WrapFile(open(targetCSPath, "w+", encoding='utf-8'))
# ParseMsgIDDefine(f, l)

# f = WrapFile(open(targetCSPath2, "w+", encoding='utf-8'))
# ParseMsgIDDef(f, l)

# f = WrapFile(open(targetMsgIDPath, "w+", encoding='utf-8'))
# ParseMsgIDDefineDic(f, l)

os.system("pause")
