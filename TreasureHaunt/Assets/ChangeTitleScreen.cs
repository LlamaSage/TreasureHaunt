using UnityEngine;

public class ChangeTitleScreen : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            this.gameObject.SetActive(false);
        }
    }
}
