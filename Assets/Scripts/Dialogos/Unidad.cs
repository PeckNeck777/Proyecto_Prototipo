using System;
using UnityEngine;

/*
 *   Estructura visual básica que empaqueta la línea de texto, el nombre del hablante 
 *   y su retrato (Sprite) correspondiente.
 */

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
