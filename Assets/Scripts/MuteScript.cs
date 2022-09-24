using UnityEngine;

public class MuteScript : MonoBehaviour
{
    bool isMute = false;
    public void MuteAudio()
    {
        if(!isMute)
        {
            AudioListener.volume = 0;
            isMute = true;    
        }
        else
        {
            AudioListener.volume = 1;
            isMute = false;
        }
    }
}
