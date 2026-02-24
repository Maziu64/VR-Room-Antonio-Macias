using UnityEngine;

public class Balls : MonoBehaviour
{
    private AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.pitch = Random.Range(0.9f, 1.1f);
        audio.PlayOneShot((AudioClip)audio.resource);
    }
}
