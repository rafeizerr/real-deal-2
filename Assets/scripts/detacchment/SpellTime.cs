using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellTime : MonoBehaviour
{
    TextMeshProUGUI time;

    // Start is called before the first frame update
    void Start()
    {

    time = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    //time.text = Manager.spellTimer.ToString();
    time.text = SorceryManager.spellTimer.ToString();
        
    }
}
