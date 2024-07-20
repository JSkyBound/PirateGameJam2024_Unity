using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Collectible : MonoBehaviour
{

    AudioSource audioData;

    [SerializeField]
    AudioClip ambient;
    [SerializeField]
    AudioClip collected;

    [SerializeField]
    GameObject VisualModel;
    [SerializeField]
    float RotationSpeed = 0.25f;



    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.clip = ambient;
        audioData.loop = true;
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        VisualModel.transform.Rotate(Vector3.up, RotationSpeed);
;   }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Collided with player, collect item:
            //TODO: IMPLEMENT ITEM COLLECTION IN PLAYER SCRIPT
            //other.gameObject.GetComponent<PlayerController>().FunctionForCollectingItem(this.itemType);

            //This should be implemented into the above mentioned function
            AudioSource playerAudio = other.gameObject.GetComponent<AudioSource>();
            playerAudio.PlayOneShot(collected);

            Cleanup();
        }

    }

    void Cleanup()
    {
        //TODO: ADD ANY HOUSEKEEPING THAT MIGHT BE NEEDED (this can probably be simplified) 
        Destroy(this.gameObject);
    }

}
