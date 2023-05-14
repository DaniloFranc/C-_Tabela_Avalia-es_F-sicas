using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo_Pollock_Seven
{
    internal class Globais
    {
        //public static string caminho = System.Environment.CurrentDirectory;
        
        public static string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

        public static string nomeBanco = "pollock_seven.db";

        public static string caminhoBanco = caminho + @"pollock_seven.db";
       
        
        // public static string caminhoBanco = caminho; o arquivo está no mesmo lugar que a pasta


    }
}
