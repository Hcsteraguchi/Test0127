using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    [SerializeField]private GameObject _pauseCanvas = default;
    public bool _isPause = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectPause()
    {
        if (!_isPause) //�|�[�Y��ʂł͂Ȃ��Ƃ�
        {
            PauseGame();
        }
        else //�|�[�Y��ʂ̂Ƃ�
        {
            RestartGame();
        }
    }
    private void PauseGame()
    {
        _pauseCanvas.SetActive(true); //�|�[�Y��ʂɈڍs
        Time.timeScale = 0f;
        _isPause = true;
    }
    private void RestartGame()
    {
        _pauseCanvas.SetActive(false);�@//�|�[�Y��ʉ���
        Time.timeScale = 1f;
        _isPause = false;
    }
}
