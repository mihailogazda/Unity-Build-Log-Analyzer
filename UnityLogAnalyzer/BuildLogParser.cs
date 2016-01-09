using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    class BuildLogParser
    {
        static readonly string m_startString = "Updating Assets/";
        static readonly string m_prePathString = "Updating ";
        static readonly string m_postPathString = " - GUID:";
        static readonly string m_stopString = " done. [Time: ";

        public static List<AssetRecord> ParseRecordsFromFile(string file)
        {
            List<AssetRecord> list = new List<AssetRecord>();

            string[] lines = File.ReadAllLines(file);

            AssetRecord currentRecord = null;
            foreach (string line in lines)
            {
                if (line.StartsWith(m_startString) && currentRecord == null)
                {
                    currentRecord = new AssetRecord();
                    currentRecord.Path = GetPathFromLine(line);
                    currentRecord.Type = AssetRecordTypeSolver.GetTypeFromPath(currentRecord.Path);
                }
                else if (line.StartsWith(m_stopString) && currentRecord != null)
                {
                    currentRecord.Time = GetTimeFromLine(line);
                    list.Add(currentRecord);
                    currentRecord = null;
                }
            }
            return list;
        }

        static string GetPathFromLine(string line)
        {
            string output = line.Substring(m_prePathString.Length);
            output = output.Substring(0, output.IndexOf(m_postPathString));
            return output;
        }

        static float GetTimeFromLine(string line)
        {
            float output = 0;
            string content = line.Substring(m_stopString.Length).Split(' ')[0];
            float.TryParse(content, out output);
            return output;
        }
    }
}
