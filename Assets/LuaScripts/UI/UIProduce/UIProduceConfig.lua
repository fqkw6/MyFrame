--[[
-- added by wsh @ 2017-12-18
-- UILoading模块窗口配置，要使用还需要导出到UI.Config.UIConfig.lua
--]]
-- 窗口配置
local UIProduce = {
    Name = UIWindowNames.UIProduce,
    Layer = UILayers.BackgroudLayer,
    -- Model = require "UI.UILoading.Model.UILoadingModel",
    Ctrl = nil,
    View = require "UI.UIProduce.View.UIProduceView",
    PrefabPath = "UI/Prefabs/View/UIProducePanel.prefab"
}

return {
    -- 配置
    UIProduce = UIProduce
}
