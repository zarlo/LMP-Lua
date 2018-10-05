using LmpGlobal;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMP_Lua
{
    [MoonSharpUserData]
    public class KSP
    {

        private Plugin plugin;

        public string MinKspVersion;
        public string MaxKspVersion;

        public KSP(Plugin plugin)
        {
            this.plugin = plugin;
            this.MaxKspVersion = LmpGlobal.KspCompatible.MaxKspVersion.ToString();
            this.MinKspVersion = LmpGlobal.KspCompatible.MinKspVersion.ToString();
        }
        

    }
}
