/* Creates a scriptable object that has tries, names, and scores

@Author Vidyoot Senthilvenkatesh
@Version 2/8/2022

*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class GameSaveManager : MonoBehaviour
{

    public List<ScriptableObject> objects = new List<ScriptableObject>();
    /**
     * Delets the persistent Data path
    **/
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
    /**
     * loads and saves objects
     **/
    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }
<<<<<<< HEAD

    /**
    * Saves objects in a secure format
    * This allows us to save the scriptable objects in a given persistent data path
    * Writes the encrypted data to a file
    */
=======
    /**
     * Saves objects in a binary format
    **/
>>>>>>> a44d25adacf308a51b6ee649e4d1bc4f75da3d34
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

    /**
<<<<<<< HEAD
    * Loads the previous user data
    * Opens, and reads from the file
    * Deserializes the file to restore prior user data
    */
=======
     * Loads objects from binary format
    **/

>>>>>>> a44d25adacf308a51b6ee649e4d1bc4f75da3d34
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