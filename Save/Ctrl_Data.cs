using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
public class Ctrl_Data : MonoBehaviour
{
    public GameData data;
    string dataFilePath;
    BinaryFormatter binaryFormatter;

    // Start is called before the first frame update
    private void Awake()
    {
        binaryFormatter = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dat";
    }

    public void UpdateData()
    {
        data.score = playData.score; //update ก่อน save
        //data.sc = playData.score;
        data.sceneNum = playData.sceneNum;
        //data.scN = playData.sceneNum;
    }

    public void SaveData()
    {
        UpdateData();
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        binaryFormatter.Serialize(fs, data);
        fs.Close();
    }

    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)binaryFormatter.Deserialize(fs);
            fs.Close();
            DisplayData(); 
        }
    }

    public void DisplayData() //เปลี่ยนตามตัวแปร
    {
        GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = data.score.ToString(); // แสดงข้อมูลเก่า
        playData.score = data.score; //ใช้คำนวนต่อ
        //GameObject.FindGameObjectWithTag("gameManager").GetComponent<Text>().text = data.sceneNum.ToString();
        playData.sceneNum = data.sceneNum;
    }

    private void OnEnable()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }
}
