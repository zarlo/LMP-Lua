using System;
using System.Text;
using MoonSharp.Interpreter;
using System.Collections.Generic;


namespace LMP_Lua
{
    public class Plugin
    {

        public Plugin()
        {

            LuaScriptManger.plugins.Add(this);

            script = new Script();

            script.Globals["KSP"] = ;
            script.Globals.Set("RegisterHandler", RegisterHandler);


        }

        public Script script { get; set; }
        public Dictionary<string, List<string>> Handlers = new Dictionary<string, List<string>>();
        
        private void RemoveHandler(string Name, string func)
        {

            Handlers[Name].Remove(func);

        }

        private void RegisterHandler(string Name, string func)
        {

            Handlers[Name].Add(func);

        }

    }
}
