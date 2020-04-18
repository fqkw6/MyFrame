--  please create lue file
local TestNoticeTip = require "GameTest/ModuleTest/TestNoticeTip"
local TestKeepModel = require "GameTest/ModuleTest/TestKeepModel"
local TestLogWinStack = require "GameTest/ModuleTest/TestLogWinStack"
local CustomTest = require "GameTest/CustomTest/CustomTest"

local function FullGC()
	collectgarbage("collect") 
	print("Mem : "..collectgarbage("count").."KB") 
end

return {
	["01、Full GC"] = FullGC,
	["02、Test Tip"] = TestNoticeTip.Run,
	["03、Keep Model"] = TestKeepModel.Run,
	["04、Log WinStack"] = TestLogWinStack.Run,
	["05、Custom Test"] = CustomTest.Run,
}