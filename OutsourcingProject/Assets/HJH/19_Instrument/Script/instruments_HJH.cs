using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruments_HJH : MonoBehaviour
{
    public AudioClip sound;
    public enum InstrumentsType
    {
        Base,
        Drum,
        Guitar,
        Harp,
        Horn,
        Mascara,
        Sexphone,
        Silopone,
        Tamberine,
        Trumpet,
        Ukurale,
        Violin,
        Zambae,
    }
    public enum Type
    {
        down,
        wait,
    }

    public InstrumentsType instruments;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
