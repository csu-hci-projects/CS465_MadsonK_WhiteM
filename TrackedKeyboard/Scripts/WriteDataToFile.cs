using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class WriteDataToFile : MonoBehaviour
{
    static string fileName;
    static string filePath;
    static Dictionary<bool, (int, int, double, double)> data = new Dictionary<bool, (int, int, double, double)>();
   
    void Start()
    {
        //fileName = System.DateTime.Now.ToString("HH-mm-ss") + "_tiger.csv";
        //filePath = Path.Combine(Application.persistentDataPath, fileName);

        fileName = "DataFiles/" + System.DateTime.Now.ToString("HH-mm-ss") + "_tiger.csv";
        filePath = Path.Combine(Application.dataPath, fileName);
    }

 
    public void GetData(int totalErrorCounter, int finalErrors, double timeTaken, double totalWPM, bool isHighlighted)
    {
        if(timeTaken == 0)
        {
            return;
        }
        if (!data.ContainsKey(isHighlighted))
        {
            data[isHighlighted] = (totalErrorCounter, finalErrors, timeTaken, totalWPM);
            WriteData();
        }
    }

    private void WriteData()
    {
        using(var writer = new StreamWriter(filePath,true))
        {
            foreach(var pair in data)
            {
                writer.WriteLine("{0},{1},", pair.Key, pair.Value);
            }
            Debug.Log("Wrote to file " + fileName);
        }
    }
  
}
