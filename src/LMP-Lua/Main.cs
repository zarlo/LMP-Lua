using System;
using Server.Client;
using Server.Plugin;
using LunaCommon.Message.Interface;

namespace LMP_Lua
{
    public class Main : ILmpPlugin
    {
        public void OnClientAuthenticated(ClientStructure client)
        {

            LuaScriptManger.CallHandler("OnClientAuthenticated", client);

        }

        public void OnClientConnect(ClientStructure client)
        {

            LuaScriptManger.CallHandler("OnClientConnect", client);

        }

        public void OnClientDisconnect(ClientStructure client)
        {

            LuaScriptManger.CallHandler("OnClientDisconnect", client);

        }

        public void OnMessageReceived(ClientStructure client, IClientMessageBase messageData)
        {

            LuaScriptManger.CallHandler("OnMessageReceived", client, messageData);

        }

        public void OnMessageSent(ClientStructure client, IServerMessageBase messageData)
        {

            LuaScriptManger.CallHandler("OnMessageSent", client, messageData);

        }

        public void OnServerStart()
        {

            LuaScriptManger.LoadPlugins();

            LuaScriptManger.CallHandler("OnServerStart");

        }

        public void OnServerStop()
        {

            LuaScriptManger.CallHandler("OnServerStop");

        }

        public void OnUpdate()
        {

            LuaScriptManger.CallHandler("OnUpdate");

        }
    }
}
