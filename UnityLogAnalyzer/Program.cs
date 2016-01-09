using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    class Program
    {
        public static void PrintUsage()
        {
            Console.WriteLine("Unity3d Build Log Analyzer v.1.0.0");
            Console.WriteLine("Usage: ");
            Console.WriteLine("\tinput_filename output_filename [filter]");
            Console.WriteLine("\tPossible filter types: ");
            foreach (AssetRecordType t in Enum.GetValues(typeof(AssetRecordType)))
            {
                Console.WriteLine("\t\t" + t + "(" + AssetRecordTypeSolver.GetExtensionsFromType(t) + ")");
            }
            Console.WriteLine("");
            Console.WriteLine("\t\tYou can combine more filters using | separator, or like this: ");
            Console.WriteLine("\t\tTexture|Lightmap|Code");
        }

        static void Main(string[] args)
        {
            //  Check input params
            if (args.Length < 2)
            {
                PrintUsage();
                return;
            }

            //  Run analyzer            
            BuildLogAnalyzer.Analyze(args[0], args[1], args.Length > 2 ? args[2] : null);
        }
    }
}
