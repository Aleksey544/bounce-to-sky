using UnityEngine;

public class GameInit : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Ins.PlayGameMusic();
    }
}
