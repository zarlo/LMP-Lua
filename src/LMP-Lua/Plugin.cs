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
            script.Globals["LMP"] = new LMP();
            script.Globals["RegisterHandler"] = (Func<string, string, bool>)RegisterHandler;
            script.Globals["RemoveHandler"] = (Func<string, string, bool>)RemoveHandler;
            script.Globals["RegisterCommand"] = (Func<string, string, string, bool>)RegisterCommand;


        }

        public Script script { get; set; }
        public Dictionary<string, List<string>> Handlers = new Dictionary<string, List<string>>();

        public void CallHandler(string Name, params object[] data)
        {

            if (Handlers.ContainsKey(Name))
                foreach (string Handler in Handlers[Name])
                {
                    try
                    {
                        script.Call(script.Globals[Handler], data);
                    }
                    catch
                    {
                        
                    }
                }
            
        }

        public bool RemoveHandler(string Name, string func)
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

        public bool RegisterHandler(string Name, string func)
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

        public bool RegisterCommand(string Name, string func, string description)
        {

            try
            {

                new CommandBase(this, Name, func, description);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }

        }

    }
}
