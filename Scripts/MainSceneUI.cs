using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUI : MonoBehaviour
{
    private PauseScene _pauseScene = default;
    [SerializeField] private SubWeaponUI _subWeaponUI;
    [SerializeField] private GameObject _inventoryCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _pauseScene = GetComponent<PauseScene>();
        _subWeaponUI = GetComponent<SubWeaponUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //ポーズ画面用スクリプトを呼び出す
        {
            _pauseScene.SelectPause();
        }
        if(Input.GetKeyDown(KeyCode.RightShift)) //サブウェポン用スクリプトを呼びだす
        {
            _subWeaponUI.InventoryDisplay();
        }

    }
}
