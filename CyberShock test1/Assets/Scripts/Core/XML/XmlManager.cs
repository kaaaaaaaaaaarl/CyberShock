using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AkshayDhotre.GraphicSettingsMenu
{
    public static class XmlManager<T>
    {
        public static void Save(T obj, string directoryPath, string fileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                FileStream stream;

                stream = new FileStream(directoryPath + fileName, FileMode.Create);

                xmlSerializer.Serialize(stream, obj);
                stream.Close();
            }
        }
        public static T Load(string path, T defaultT)
        {
            T result = defaultT;

            if (!string.IsNullOrEmpty(path))
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                XmlReader reader = XmlReader.Create(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                if (serializer.CanDeserialize(reader))
                {
                    try
                    {
                        result = (T)serializer.Deserialize(reader);
                    }catch
                    {
                        result = defaultT;
                        Debug.LogError("File in path : " + path + ", contains invalid data");
                    }
                }

                stream.Close();
            }

            return result;
        }
        public static bool FileExists(string path)
        {
            if(File.Exists(path))
            {
                return true;
            }

            return false;
        }
    }
}


