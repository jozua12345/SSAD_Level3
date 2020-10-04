using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class EndSceneManager : MonoBehaviour {
    public Button button;
    public GameObject panel;
    public GameObject t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEndScene() {
        panel.SetActive(false);
        t.GetComponent<PlayableDirector>().Play();
    }
}
