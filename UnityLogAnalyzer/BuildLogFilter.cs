using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    /// <summary>
    /// Filter log parser
    /// </summary>
    class BuildLogFilter
    {
        List<AssetRecordType> m_types = new List<AssetRecordType>();

        public BuildLogFilter(string input)
        {
            string[] inputs = input.Split('|');

            foreach (string option in inputs)
            {
                foreach (AssetRecordType type in Enum.GetValues(typeof(AssetRecordType)))
                {
                    if (type.ToString().Equals(option))
                    {
                        m_types.Add(type);
                    }
                }
            }
        }

        public bool AllowedType(AssetRecordType type)
        {
            foreach (AssetRecordType t in m_types)
            {
                if (t.Equals(type))
                    return true;
            }
            return false;
        }
    }
}
