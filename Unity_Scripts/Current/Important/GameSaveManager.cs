using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class GameSaveManager : MonoBehaviour
{

    public List<ScriptableObject> objects = new List<ScriptableObject>();
    //Delets the persistent Data path
    public void ResetScriptables()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            if(File.Exists(Application.persistentDataPath +
                string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath +
                    string.Format("/{0}.dat", i));
            }
        }
    }
//loads and saves objects
    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }
//Saves objects in a binary format
    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i ++)
        {
            FileStream file = File.Create(Application.persistentDataPath +
                string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }
//Loads objects from binary format
    public void LoadScriptables()
    { 
        for(int i = 0; i < objects.Count; i ++)
        { 
            if(File.Exists(Application.persistentDataPath +
                string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath +
                    string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
                    objects[i]);
                file.Close();
            }
        }

    }

}