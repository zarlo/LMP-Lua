using LunaCommon.Message.Interface;
using MoonSharp.Interpreter;
using Server.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMP_Lua
{
    [MoonSharpUserData]
    public class LMP
    {
        [MoonSharpUserData]
        public class Logger
        {

            public void Log(string message)
            {

                Server.Log.LunaLog.Normal("[LUA]" + message);

            }

            public void Error(string message)
            {

                Server.Log.LunaLog.Error("[LUA]" + message);

            }

            public void Warning(string message)
            {

                Server.Log.LunaLog.Warning("[LUA]" + message);

            }

        }

        [MoonSharpUserData]
        public class Networking
        {

            [MoonSharpUserData]
            public class MessageQueuer
            {

                public void RelayMessageToSubspace<T>(ClientStructure exceptClient, IMessageData data) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.RelayMessageToSubspace<T>(exceptClient, data);
                }


                public void SendMessageToSubspace<T>(IMessageData data, int subspace) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.SendMessageToSubspace<T>(data, subspace);
                }


                public void RelayMessageToSubspace<T>(ClientStructure exceptClient, IMessageData data, int subspace) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.RelayMessageToSubspace<T>(exceptClient, data, subspace);
                }


                public void RelayMessage<T>(ClientStructure exceptClient, IMessageData data) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.RelayMessage<T>(exceptClient, data);
                }


                public void SendToAllClients<T>(IMessageData data) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.SendToAllClients<T>(data);
                }


                public void SendToClient<T>(ClientStructure client, IMessageData data) where T : class, IServerMessageBase
                {
                    Server.Server.MessageQueuer.SendToClient<T>(client, data);
                }


                public void SendConnectionEnd(ClientStructure client, string reason)
                {
                    Server.Server.MessageQueuer.SendConnectionEnd(client, reason);
                }


                public void SendConnectionEndToAll(string reason)
                {
                    Server.Server.MessageQueuer.SendConnectionEndToAll(reason);
                }

            }


            public MessageQueuer messagequeuer;

            public Networking()
            {

                this.messagequeuer = new MessageQueuer();

            }

        }

        public Logger logger;
        public Networking networking;


        public LMP()
        {

            this.networking = new Networking();
            this.logger = new Logger();

        }

    }
}
