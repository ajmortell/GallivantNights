using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

[System.Serializable]
[XmlRoot("PlayerData")]
public class PlayerData {
   
    [XmlElement("LastWeaponIndex")]
    public int LastWeaponIndex;
    [XmlElement("Progress")]
    public string Progress;
    [XmlArray("BulletData"), XmlArrayItem("Bullet")]
    public List<BulletData> Bullets;

    public PlayerData() {
        Bullets = new List<BulletData>();
    }

    public static PlayerData LoadPlayerData(string path) {
        XmlSerializer xml = new XmlSerializer(typeof(PlayerData));
        StreamReader reader = new StreamReader(path);
        PlayerData data = (PlayerData)xml.Deserialize(reader);
        return data;
    }

    public static void SavePlayerData(string path) {
        PlayerData data = new PlayerData();
        XmlSerializer xml = new XmlSerializer(typeof(PlayerData));    
        StreamWriter writer = new StreamWriter(path);
        xml.Serialize(writer,data);
    }
}
