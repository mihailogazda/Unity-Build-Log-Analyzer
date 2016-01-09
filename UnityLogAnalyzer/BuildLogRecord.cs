using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    /// <summary>
    /// Record types
    /// </summary>
    enum AssetRecordType
    {
        Texture,
        Code,
        Mesh,
        Lightmap,
        UnityAsset,
        Audio,
        Other
    };

    /// <summary>
    /// Single build record
    /// </summary>
    class AssetRecord
    {
        /// <summary>
        /// Path of the asset
        /// </summary>
        public string Path = null;

        /// <summary>
        /// Identifies record type
        /// </summary>
        public AssetRecordType Type = AssetRecordType.Other;

        /// <summary>
        /// Time took for a record to build
        /// </summary>
        public float Time = 0.0f;

    }
    

}
