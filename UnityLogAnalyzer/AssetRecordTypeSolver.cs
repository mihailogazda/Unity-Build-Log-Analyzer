using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLogAnalyzer
{
    /// <summary>
    /// Resolves path into asset record type
    /// </summary>
    class AssetRecordTypeSolver
    {
        static Dictionary<AssetRecordType, string[]> TypeExtensionMap = new Dictionary<AssetRecordType, string[]>
        {
            {
                AssetRecordType.Texture,
                new string[]
                {
                    ".tga", ".png",
                    ".bmp", ".jpg",
                }
            },
            {
                AssetRecordType.Mesh,
                new string[]
                {
                    ".fbx", ".obj",
                }
            },
            {
                AssetRecordType.Code,
                new string[]
                {
                    ".cs", ".json",
                    ".py", ".txt",
                }
            },
            {
                AssetRecordType.Lightmap,
                new string[]
                {
                    ".exr", ".cubemap",
                }
            },
            {
                AssetRecordType.Audio,
                new string[]
                    {
                        ".wav", ".sfk",
                        ".ogg",
                    }
            },
            {
                AssetRecordType.UnityAsset,
                new string[]
                {
                    ".prefab", ".unity",
                    ".anim",".shader",
                    ".asset", ".mat",
                }
            },
            {
                AssetRecordType.Other,
                null
            }
        };


        private static bool CompareExtension(string path, string extension)
        {
            if (path == null)
                return false;
            return path.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool CompareExtensionList(string path, string[] extensions)
        {
            if (extensions == null)
                return false;

            foreach (string ext in extensions)
            {
                if (CompareExtension(path, ext))
                {
                    return true;
                }
            }
            return false;
        }

        public static AssetRecordType GetTypeFromPath(string path)
        {
            AssetRecordType type = AssetRecordType.Other;

            foreach (var exts in TypeExtensionMap)
            {
                if (CompareExtensionList(path, exts.Value))
                {
                    type = exts.Key;
                    break;
                }
            }

            return type;
        }

        public static string GetExtensionsFromType(AssetRecordType type)
        {
            string[] exts = TypeExtensionMap[type];
            if (exts == null)
                return null;
            return String.Join(" ", exts);
        }
    }
}
