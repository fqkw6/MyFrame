local pb = require "pb"
local bytes
function InitPB()
    --初始化pb文件，路径采用绝对路径
    assert(pb.loadfile "Assets/LuaScripts/Net/Proto/login.pb")
end
local function Encoder()
    local data = {
        flag = "666"
    }

    -- encode lua table data into binary format in lua string and return
    bytes = assert(pb.encode("login.req_login", data))
    ---压缩
    Logger.LogError(pb.tohex(bytes))
    return bytes
end

function Decoder(pb_data)
    -- and decode the binary data back into lua table
    local data2 = assert(pb.decode("login.req_login", bytes))
    ---解压
    -- Logger.LogError("cesss")
    -- Logger.LogError(data2.flag)
end

local function Run()
    -- Logger.LogError("------------Test lua_PB------------")

    InitPB()

    local pb_data = Encoder()
    Decoder(pb_data)
end

return {
    Run = Run
}
