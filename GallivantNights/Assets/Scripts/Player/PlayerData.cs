using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

[System.Serializable]
[XmlRoot("PlayerData")]
public class PlayerData {

    [XmlElement("LastWeaponIndex")]
    public int LastWeaponIndex;
    [XmlElement("LastSceneID")]
    public int LastSceneID;
    [XmlElement("SinglegunBullets")]
    public int SinglegunBullets;
    [XmlElement("DoubleshotBullets")]
    public int DoubleshotBullets;
    [XmlElement("BurstgunBullets")]
    public int BurstgunBullets;
    [XmlElement("CanonBullets")]
    public int CanonBullets;

    public PlayerData() {
    }

    public static PlayerData LoadPlayerData(string path) {
        XmlSerializer xml = new XmlSerializer(typeof(PlayerData));
        StreamReader reader = new StreamReader(path);
        PlayerData dialogue = (PlayerData)xml.Deserialize(reader);
        return dialogue;
    }
}
