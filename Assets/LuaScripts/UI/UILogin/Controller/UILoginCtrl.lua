--[[
-- added by wsh @ 2017-12-01
-- UILogin控制层
--]]
local UILoginCtrl = BaseClass("UILoginCtrl", UIBaseCtrl)

local function OnConnect(self, sender, result, msg)
    if result < 0 then
        Logger.LogError("Connect err : " .. msg)
        return
    end

    -- TODO：
    local msd_id = MsgIDDefine.LOGIN_REQ_LOGIN

    local msg = {}
    msg.flag = 455555
    Logger.Log("fasong")
    Logger.Log(msd_id)
    SingleGet.HallConnector():SendMessage(msd_id, msg)
end

local function OnClose(self, sender, result, msg)
    if result < 0 then
        Logger.LogError("Close err : " .. msg)
        return
    end
end

local function ConnectServer(self)
    SingleGet.HallConnector():Connect("127.0.0.1", 8088, Bind(self, OnConnect), Bind(self, OnClose))
    --SingleGet.HallConnector():Connect("127.0.0.1", 10020, OnConnect, OnClose)
end

local function LoginServer(self, name, password)
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
    Logger.Log("ceshi ")
    -- TODO start socket
    ConnectServer(self)
    SingleGet.SceneManager():SwitchScene(SceneConfig.HomeScene)
end

local function ChooseServer(self)
    SingleGet.UIManager():OpenWindow(UIWindowNames.UILoginServer)
end

UILoginCtrl.LoginServer = LoginServer
UILoginCtrl.ChooseServer = ChooseServer

return UILoginCtrl
