using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    #region //インスペクター変数
    [SerializeField] private RectTransform[] _arrowPos = default;　
    [SerializeField] private Image _selectInventory = default;
    [SerializeField] private Image _nowInventory = default;
    [SerializeField] public Image[] _inventoryes = default;
    [SerializeField] private GameObject _gameController = default;
    [SerializeField] private PauseScene _pauseScene = default;
    [SerializeField] private SubWeaponUI _subWeaponUI = default;
    #endregion
    // パブリック変数
    public int _selectNum = default;

    // Start is called before the first frame update
    void Start()
    {
        // 
        _pauseScene = _gameController.GetComponent<PauseScene>();　
        _subWeaponUI = _gameController.GetComponent<SubWeaponUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_pauseScene._isPause)　//ポーズ画面になっているかどうか
        {
            InventorySelect();
        }
    }
    private void InventorySelect()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //右選択肢
        {
            _selectNum++;
            InventoryNumber();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))　//左選択肢
        {
            _selectNum--;
            if (_selectNum < 0)
            {
                _selectNum += _arrowPos.Length;
            }
            InventoryNumber();
        }
        if (Input.GetKeyDown(KeyCode.Return))　// 決定ボタン
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
        Image selectImages = _inventoryes[_selectNum]; // 画像情報を取得
        _nowInventory.sprite = selectImages.sprite;　// 選択画像を現在のインベントリに添付
        _subWeaponUI.InventoryDisplay();　// 決定後インベントリ画面を削除
    }
}
