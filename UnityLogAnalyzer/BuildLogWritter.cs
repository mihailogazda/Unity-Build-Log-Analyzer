using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    /// <summary>
    /// Builds a CSV file out of AssetRecords
    /// </summary>
    class BuildLogWritter
    {
        public static void Write(ref List<AssetRecord> records, string outputPath, BuildLogFilter filter = null)
        {
            string output = "";
            foreach (AssetRecord record in records)
            {
                if (filter != null && !filter.AllowedType(record.Type))
                    continue;

                output += CSVLineFromRecord(record) + "\n";
            }
            File.WriteAllText(outputPath, output);
        }

        static string CSVLineFromRecord(AssetRecord record)
        {
            return record.Path + "," + record.Type + "," + record.Time;
        }

    }
}
