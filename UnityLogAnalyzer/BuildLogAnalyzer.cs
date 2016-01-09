using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    /// <summary>
    /// Analyzer of build log
    /// </summary>
    class BuildLogAnalyzer
    {
        public static void Analyze(string inputFile, string outputFile, string filter = null)
        {
            if (!File.Exists(inputFile))
            {
                throw new Exception("Input file cannot be found");
            }

            List<AssetRecord> records = BuildLogParser.ParseRecordsFromFile(inputFile);
            if (records.Count > 0)
            {
                BuildLogFilter realFilter = null;
                if (filter != null)
                {
                    realFilter = new BuildLogFilter(filter);
                }

                BuildLogWritter.Write(ref records, outputFile, realFilter);
            }
        }
    }
}
