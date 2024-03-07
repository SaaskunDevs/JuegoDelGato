using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "InfoPopUP", fileName = "New Information")]
public class InfoSO : ScriptableObject
{
    [TextArea(2,6)] //Nos sirve para darle al usuario un minimo y limite
                    //De espacios de texto.
    public string tilte = "Enter new title text here";
    
    [TextArea(2, 6)]
    public string info = "Enter new Pop Up information";

}
