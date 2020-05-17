--[[
-- added by wsh @ 2017-12-01
-- UILogin控制层
--]]
---@class UILoginCtrl:UIBaseCtrl
local UILoginCtrl = BaseClass("UILoginCtrl", UIBaseCtrl)
local MsgIDDefine = require "Net.Config.MsgIDDefine"

function UILoginCtrl:OnConnect(sender, result, msg)
    if result < 0 then
        Logger.LogError("Connect err : " .. msg)
        return
    end

    -- TODO：
    local msd_id = MsgIDDefine.LOGIN_REQ_GET_UID
    local msg = {}
    msg.plat_account = "455445"
    msg.from_svrid = 4001
    msg.device_id = ""
    msg.device_model = "All Series (ASUS)"
    msg.mobile_type = ""
    msg.plat_token = ""
    msg.app_ver = ""
    msg.package_id = ""
    msg.res_ver = ""
    SingleGet.HallConnector():SendMessage(msd_id, msg)
end

function UILoginCtrl:OnClose(sender, result, msg)
    if result < 0 then
        Logger.LogError("Close err : " .. msg)
        return
    end
end

function UILoginCtrl:ConnectServer()
    SingleGet.HallConnector():Connect("192.168.1.245", 10020, Bind(self, OnConnect), Bind(self, OnClose))
end

function UILoginCtrl:LoginServer(name, password)
    -- 合法性检验
    if string.len(name) > 20 or string.len(name) < 1 then
        -- TODO：错误弹窗
        Logger.LogError("name length err!")
        return
    end
    if string.len(password) > 20 or string.len(password) < 1 then
        -- TODO：错误弹窗
        Logger.LogError("password length err!")
        return
    end
    -- 检测是否有汉字
    for i = 1, string.len(name) do
        local curByte = string.byte(name, i)
        if curByte > 127 then
            -- TODO：错误弹窗
            Logger.LogError("name err : only ascii can be used!")
            return
        end
    end

    SingleGet.ClientData():SetAccountInfo(name, password)

    -- TODO start socket
    --ConnectServer(self)
    SingleGet.SceneManager():SwitchScene(SceneConfig.HomeScene)
end
function UILoginCtrl:ChooseServer()
    SingleGet.UIManager():OpenWindow(UIWindowNames.UILoginServer)
end

return UILoginCtrl
