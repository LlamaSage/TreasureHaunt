using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GhostRadarManager : MonoBehaviour
{
    public string inputButton = "A_P1";
    public GhostRadarMode mode = GhostRadarMode.DISTANCE;

    private GameObject ghost;
    private GameObject[] players;

    private AudioSource radarSound;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        ghost = GameObject.FindGameObjectWithTag("Ghost");

        radarSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (players.Length != 0 && Input.GetButtonDown(inputButton))
        if (players.Length != 0 && ghost && (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown(inputButton))) //TODO only ButtonDown & CORRECT BUTTON!!!!
        {
            Debug.DrawRay(ghost.transform.position, ghost.transform.forward, Color.white, 5f);

            Debug.DrawLine(ghost.transform.position, players[0].transform.position, Color.red, 2f);
            Debug.DrawLine(ghost.transform.position, players[1].transform.position, Color.green, 2f);
            Debug.DrawLine(ghost.transform.position, players[2].transform.position, Color.blue, 2f);

            if (mode == GhostRadarMode.DISTANCE)
            {
                if (!radarSound.isPlaying)
                {
                    float minDistance = Mathf.Infinity;
                    GameObject closestPlayer = players[0];

                    for (int i = 0; i < players.Length; i++)
                    {
                        float dist = Vector3.Distance(ghost.transform.position, players[i].transform.position);
                        if (dist < minDistance)
                        {
                            minDistance = dist;
                            closestPlayer = players[i];
                        }
                    }

                    transform.position = closestPlayer.transform.position;
                    radarSound.Play();

                    Debug.Log(closestPlayer.name);
                }                
            }
            else
            {
                if (!radarSound.isPlaying)
                {
                    float minAngle = Mathf.Infinity;
                    GameObject playerMostInFront = players[0];

                    for (int i = 0; i < players.Length; i++)
                    {
                        float angle = Mathf.Abs(Vector3.SignedAngle(ghost.transform.forward, players[i].transform.position - ghost.transform.position, Vector3.up));
                        Debug.DrawRay(ghost.transform.position, players[i].transform.position - ghost.transform.position, Color.cyan, 5f);

                        if (angle < minAngle)
                        {
                            minAngle = angle;
                            playerMostInFront = players[i];
                        }
                    }

                    transform.position = playerMostInFront.transform.position;
                    radarSound.Play();

                    Debug.Log(playerMostInFront.name);
                }
            }
        }
        
    }
}

public enum GhostRadarMode {ANGLE, DISTANCE}
