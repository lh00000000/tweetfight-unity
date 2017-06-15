using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO; // using "Socket.IO for Unity" by Fabio Panettieri
using UnityEngine.UI;


public class DisplayTweetsBehavior : MonoBehaviour {

    SocketIOComponent socket;
    public GameObject socketIOObj;
    public Text textObj;
    public GameObject sadCube;
    public GameObject happyCube;
    public int pushPower;

    // Use this for initialization
    void Start () {
        pushPower = 30;
        Debug.Log ("poop");

        socket = socketIOObj.GetComponent<SocketIOComponent> ();

        socket.On ("sadtweet", ReceiveTweet);
        socket.On ("happytweet", ReceiveTweet);

        socket.On ("sadtweet", SadTweet);
        socket.On ("happytweet", HappyTweet);
    }

    // Update is called once per frame
    void Update () {

    }
    public void ReceiveTweet(SocketIOEvent e) {
        textObj.text = e.data["text"].ToString();
    }

    public void pushCube(GameObject cube) {
        cube.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, pushPower, 0));
    }

    public void SadTweet(SocketIOEvent e) {
        pushCube (sadCube);
    }

    public void HappyTweet(SocketIOEvent e) {
        pushCube (happyCube);
    }
}
