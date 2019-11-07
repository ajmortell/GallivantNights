using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

[System.Serializable]
public class BulletData {

    [XmlElement("BulletID")]
    public int BulletID;
    [XmlElement("BulletName")]
    public string BulletName;
    [XmlElement("BulletCache")]
    public int BulletCache;

    public BulletData() {

    }
}
