using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Serialization
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Persistencia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Guarda el estado del juego en un .dat
    /// crea el archivo y lo guarda.
    /// Application.persistentDataPath es independiente del dispositivo
    /// 
    /// </summary>
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Records.dat");

        //PlayerData data = new PlayerData(Diamantes, Estrellas, nivelesAccesibles, estrellasPorNivel, puntosPorNivel);
        Records data = new Records();
        //Serializamos data y lo guardamos en file
        bf.Serialize(file, data);

        //Cerramos file
        file.Close();
    }

    /// <summary>
    /// Carga el estado del archivo .dat previamente creado
    /// si este existiera.
    /// </summary>
    public void Load()
    {
        //Comprobamos si el archivo existe antes de abrirlo
        if (File.Exists(Application.persistentDataPath + "/Records.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Records.dat", FileMode.Open);

            //Tenemos que castear la deserializacion que ha leido a Playerdata
            //PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
        }

    }

    /// <summary>
    /// Reset de los valores del GameManager al estado inicial
    /// </summary>
    public void Reset()
    {
        
    }


    //Datos que vamos a guardar en el .dat; Se podría hacer mejor.
    //Estos datos se tienen que serializar
    [System.Serializable]
    class Records : System.Object
    {
       
    }

}
