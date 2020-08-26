using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestion : MonoBehaviour
{
    public GameObject QuestionPanels;
    public OVRScreenFade fadeMaster;
    public float fadeSeconds = 1.0f;
    private GameObject _player;
    private OVRPlayerController _playerRB;
    private float playerAcceleration = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeOutIn());
        }
    }

    public IEnumerator FadeOutIn()
    {
        //Fade In and Fade Out
        fadeMaster.FadeOut();
        yield return new WaitForSeconds(fadeSeconds);
        _playerRB.Acceleration = 0.0f;
        fadeMaster.FadeIn();
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRB = _player.GetComponent<OVRPlayerController>();
        playerAcceleration = _playerRB.Acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
