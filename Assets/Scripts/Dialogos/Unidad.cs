using System;
using UnityEngine;

[Serializable]
public class Unidad
{
    [SerializeField]
    string spaeker;
    [SerializeField]
    Sprite portrait;
    [SerializeField]
    string line;

    public string Speaker { get {  return spaeker; } }
    public Sprite Portrait { get { return portrait; } }
    public string Line { get { return line; } }    
}
