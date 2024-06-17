using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    #region //�C���X�y�N�^�[�ϐ�
    [SerializeField] private RectTransform[] _arrowPos = default;�@
    [SerializeField] private Image _selectInventory = default;
    [SerializeField] private Image _nowInventory = default;
    [SerializeField] public Image[] _inventoryes = default;
    [SerializeField] private GameObject _gameController = default;
    [SerializeField] private PauseScene _pauseScene = default;
    [SerializeField] private SubWeaponUI _subWeaponUI = default;
    #endregion
    // �p�u���b�N�ϐ�
    public int _selectNum = default;

    // Start is called before the first frame update
    void Start()
    {
        // 
        _pauseScene = _gameController.GetComponent<PauseScene>();�@
        _subWeaponUI = _gameController.GetComponent<SubWeaponUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_pauseScene._isPause)�@//�|�[�Y��ʂɂȂ��Ă��邩�ǂ���
        {
            InventorySelect();
        }
    }
    private void InventorySelect()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //�E�I����
        {
            _selectNum++;
            InventoryNumber();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))�@//���I����
        {
            _selectNum--;
            if (_selectNum < 0)
            {
                _selectNum += _arrowPos.Length;
            }
            InventoryNumber();
        }
        if (Input.GetKeyDown(KeyCode.Return))�@// ����{�^��
        {
            InventoryDecision();
        }
    }
    private void InventoryNumber()
    {
        _selectNum %= _arrowPos.Length;
        _selectInventory.rectTransform.anchoredPosition = _arrowPos[_selectNum].anchoredPosition;
       
    }
    public void InventoryDecision()
    {
        Image selectImages = _inventoryes[_selectNum]; // �摜�����擾
        _nowInventory.sprite = selectImages.sprite;�@// �I���摜�����݂̃C���x���g���ɓY�t
        _subWeaponUI.InventoryDisplay();�@// �����C���x���g����ʂ��폜
    }
}
