using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public AudioSource Steps;
    public AudioSource Gems;
    public AudioClip paso1;
    public AudioClip paso2;
    public AudioClip catchGem;

    private int RamSteps; 

    // Start is called before the first frame update
    public void Start()
    {
        Steps = GetComponent<AudioSource>();
        Gems = GetComponent<AudioSource>();      
    }

    // Update is called once per frame
    public void Update()
    {
        RamSteps = Random.Range(1, 3);

        FootSound(RamSteps);
    }



    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            CatchGem();
        }
    }

    private void FootSound(int Ram)
    {
        switch (Ram)
        {
            case 1:
                Steps.clip = paso1;
                break;
            case 2:
                Steps.clip = paso2;
                break;
        }
        Steps.Play();
    }

    private void CatchGem()
    {
        Gems.clip = catchGem;
    }
}
