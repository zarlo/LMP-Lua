using System;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using MoonSharp.Interpreter;
using System.Collections.Generic;
using MoonSharp.Interpreter.Loaders;

namespace LMP_Lua
{
    public class LuaScriptManger
    {

        public static List<Plugin> plugins = new List<Plugin>();

        static LMP.Logger Logger = new LMP.Logger();

        public static void CallHandler(string Name, params object[] data)
        {

            foreach (Plugin plugin in plugins)
            {

                plugin.CallHandler(Name, data);

            }

        }

        public static void LoadPlugins()
        {

            Logger.Log("Loading Plugins");

            if (!Directory.Exists(Environment.CurrentDirectory + "/plugins/lua"))
            {

                Directory.CreateDirectory(Environment.CurrentDirectory + "/plugins/lua");

            }

            foreach (string Plugin in System.IO.Directory.GetDirectories(Environment.CurrentDirectory + "/plugins/lua"))
            {
                LoadPlugin(Plugin);
            }

        }

        public static void LoadPlugin(string Path)
        {

            Logger.Log("Loading " + Path + "/main.lua");

            Plugin plugin;

            try
            {
                plugin = new Plugin();
                Script.DefaultOptions.ScriptLoader = new FileSystemScriptLoader();

                plugin.script.DoString(System.IO.File.ReadAllText(Path + "/main.lua"));
                
            }
            catch(Exception ex)
            {
                Logger.Error(ex.ToString());
                Logger.Error("Failed to load " + Path + "/main.lua");
                plugin = null;
                
            }
        }


    }
}
