using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    public AudioClip collideSound;
    public AudioClip spawnSound;
    public AudioClip LandSound;
    public AudioClip BadBlockSound;
    AudioSource audioSource;
    // Use this for initialization
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        SpawnerBehaviour.BadBlockSpawned += PlayBadBlock;
        SpawnerBehaviour.BlockSpawned += PlayBlockSpawn;
        BlockBehaviour.Collided += PlayBlockCollision;

    }
    void PlayBadBlock()
    {
        if(BadBlockSound != null)
        {
            audioSource.clip = BadBlockSound;
            audioSource.Play();
        }
    }
    void PlayBlockSpawn()
    {
        if(spawnSound != null)
        {
            audioSource.clip = spawnSound;
            audioSource.Play();
        }

    }
    void PlayBlockCollision()
    {
        if (collideSound != null)
        {
            audioSource.clip = collideSound;
            audioSource.Play();
        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
