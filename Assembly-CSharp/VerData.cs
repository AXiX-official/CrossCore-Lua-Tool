using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[Serializable]
public class ABVerData
{
    public string name;
    
    public int version;
    
    public uint crc;
    
    public int size;
    
    public long sizeB;
    
    public string url;
    
    public string md5;
    
    public bool isEncypt;
    
    public string key;
    
    private string path;
}

[Serializable]
public class VerInfo
{
    public string id;
    
    public string name;
    
    public List<ABVerData> abDataList = new List<ABVerData>();
    
    public Dictionary<string, ABVerData> resourceContainer;
    
    public List<string> subABList;

    private Dictionary<string, ABVerData> _neededMoveContainer;
}