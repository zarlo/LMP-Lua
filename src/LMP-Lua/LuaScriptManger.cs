using System;
using Newtonsoft.Json;
using System.Text;
using MoonSharp.Interpreter;
using System.Collections.Generic;


namespace LMP_Lua
{
    public class LuaScriptManger
    {

        public static List<Plugin> plugins = new List<Plugin>();

        public static void CallHandler(string Name, params object[] data)
        {

            foreach (Plugin plugin in plugins)
            {

                foreach (string Handler in plugin.Handlers[Name])
                {

                    plugin.script.Call(plugin.script.Globals[Handler], data);

                }

            }

        }

        public static void LoadPlugins()
        {



        }

        public static void LoadPlugin(string name)
        {

            PluginData data = JsonConvert.DeserializeObject<PluginData>(System.IO.File.ReadAllText(Environment.CurrentDirectory + name + "/plugin.json"));

            Plugin plugin = new Plugin();


            plugin.script.DoFile(data.Main);

        }


    }
}
