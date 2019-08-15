using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTracker : MonoBehaviour {

    Dictionary<int, Record> records;

	// Use this for initialization
	void Start () {
        //Tomar los records de GM -> Persistencia
        records = new Dictionary<int, Record>(10);
	}
	
    /// <summary>
    /// Comprueba si 
    /// </summary>
    /// <param name="puntos"></param>
    /// <returns></returns>
	public bool CompruebaRecord(int puntos)
    {
        return true;
    }

    private void RegistraRecord(int posicion, string nombre, int puntos)
    {
        Record record = new Record(nombre, puntos);
       
    }

    private void WriteAllRecords()
    {
        
    }
}

class Record : System.Object
{

    public Record(string nombre, int puntos)
    {
        NombreJugador = nombre;
        PuntosJugador = puntos;
    }
    private string NombreJugador { set; get; }
    private int    PuntosJugador { set; get; }
}