using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

namespace Client 
{
    [System.Serializable]
    public class PersistentData 
    {
        public Vector2 lastCheckPointPos {get;set;}
    }
    public static class SaveAndLoad 
    {
        public static void Save(PersistentData data)
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.UnityConverters.Math.Vector2Converter());

            // using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + graphName +".json"))
            using (StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/saves.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }
        public static PersistentData Load()
        {
            if (!File.Exists(Application.persistentDataPath + "/saves.json")) 
            {
                return null;
            }
            // Debug.Log(Application.persistentDataPath + "/saves.json");

            JsonSerializer serializer = new JsonSerializer();
            // serializer.Converters.Add(new Newtonsoft.Json.UnityConverters.Math.Vector2Converter());

            using (StringReader sr = new StringReader(File.ReadAllText(Application.persistentDataPath + "/saves.json")))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                
                // string readText = await reader.ReadAsync()
                return serializer.Deserialize<PersistentData>(reader);
            }
        }
    }

}
