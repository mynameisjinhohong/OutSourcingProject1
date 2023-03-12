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
    public bool start = false;
    public InstrumentsType instruments;
    public Type type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start&& type == Type.down)
        {
            start = false;
            StartCoroutine(Down());
        }
        else if(start && type == Type.wait)
        {
            start = false;
            StartCoroutine(Stay());
        }
    }

    IEnumerator Stay()
    {
        for(int i =0; i< 30; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1f));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 60; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -1f));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 30; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1f));
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 30; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1f));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 60; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -1f));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 30; i++)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1f));
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    IEnumerator Down()
    {
        while (true)
        {
            gameObject.transform.position -= new Vector3(0, 0.1f, 0);
            gameObject.transform.Rotate(new Vector3(0, 0, 1f));
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
