using MoonSharp.Interpreter;
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

        private Plugin plugin;

        public Logger logger;

        public LMP(Plugin plugin)
        {

            this.plugin = plugin;
            this.logger = new Logger();

        }

    }
}
