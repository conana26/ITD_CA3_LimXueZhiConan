using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> walkTriggers = new List<GameObject>();

    public List<GameObject> teleportAreas = new List<GameObject>();

    public GameObject doorToRemove;
    public GameObject congratsCanvas;

    private int walkProgress = 0;
    private int teleportProgress = 0;

    void Start()
    {
        if (congratsCanvas != null)
            congratsCanvas.SetActive(false);
        for (int i = 0; i < walkTriggers.Count; i++)
        {
            walkTriggers[i].SetActive(i == 0);
        }

        for (int i = 0; i < teleportAreas.Count; i++)
        {
            teleportAreas[i].SetActive(false);
        }

    }


    public int GetNextWalkIndex()
    {
        return walkProgress;
    }

    public void CompleteWalkTrigger(int index)
    {
        if (index != walkProgress) return;

        walkProgress++;

        if (walkProgress >= walkTriggers.Count)
        {
            if (doorToRemove != null)
                Destroy(doorToRemove);

            if (teleportAreas.Count > 0)
                teleportAreas[0].SetActive(true);
        }
        else
        {
            walkTriggers[walkProgress].SetActive(true);
        }

    }


    public int GetNextTeleportIndex()
    {
        return teleportProgress;
    }

    public void CompleteTeleport(int index)
    {
        if (index != teleportProgress) return;

        teleportProgress++;

        if (teleportProgress < teleportAreas.Count)
        {
            teleportAreas[teleportProgress].SetActive(true);
        }

        Debug.Log("Teleport Progress: " + teleportProgress + "/" + teleportAreas.Count);

        CheckTutorialComplete();
    }
    void CheckTutorialComplete()
    {
        bool walkDone = walkProgress >= walkTriggers.Count;
        bool teleportDone = teleportProgress >= teleportAreas.Count;
        if (walkDone && teleportDone)
        {
            if (congratsCanvas != null)
                congratsCanvas.SetActive(true);
        }
    }
}