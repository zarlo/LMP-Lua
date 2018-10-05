using System;
using MoonSharp.Interpreter;
using System.Collections.Generic;
using MoonSharp.Interpreter.Loaders;

namespace LMP_Lua
{
    public class Plugin
    {

        static LMP.Logger Logger = new LMP.Logger();

        public Plugin()
        {

            LuaScriptManger.plugins.Add(this);                    

            script = new Script();
            script.Globals["KSP"] = new KSP(this);
            script.Globals["LMP"] = new LMP(this);
            script.Globals["RegisterHandler"] = (Func<string, string, bool>)RegisterHandler;
            script.Globals["RemoveHandler"] = (Func<string, string, bool>)RemoveHandler;
            

        }

        public Script script { get; set; }
        public Dictionary<string, List<string>> Handlers = new Dictionary<string, List<string>>();
        
        bool RemoveHandler(string Name, string func)
        {

            try
            {
                Logger.Log("removed " + Name + ":" + func);
                Handlers[Name].Remove(func);
                return true;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
                

        }

        bool RegisterHandler(string Name, string func)
        {

            try
            {
                Logger.Log("added " + Name + ":" + func);
                if (!Handlers.ContainsKey(Name))
                {
                    Handlers.Add(Name, new List<string>());
                }
                Handlers[Name].Add(func);
                return true;
            }
            catch(Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }

        }

    }
}
