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

        public KSP(Plugin plugin)
        {
            this.plugin = plugin;
            
        }
        

    }
}
