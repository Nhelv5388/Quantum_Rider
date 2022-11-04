using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get => _instance; }
    static PlayerManager _instance;

    private GameObject playerObject;
    private GameObject startObject;
    private int _returnHP=0;

    MapManager mapManager;

    private void Awake()
    {

        mapManager = MapManager.Instance;
        if(Instance == null)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        startObject = GameObject.FindGameObjectWithTag("Start");
    }
    public int Damage(int Damage,int HP)//�_���[�W����
    {
        //�v���C���[��HP�o�[����낤��
        HP -= Damage;
        _returnHP= HP;
        if (_returnHP <= 0)
        {
            //MapManager.Instance.SceneChange(MapManager.SceneID.GameOver);
            mapManager.SceneChange(MapManager.SceneID.GameOver);
        }
        return _returnHP;
               
    }
    public int Heal(int Heal, int HP, int MaxHP)//�̗͉�
    {
        
        //�v���C���[��HP�o�[����낤��
        HP += Heal;
        _returnHP = HP;
        if (_returnHP > MaxHP)
        {
            _returnHP= MaxHP;
        }
        return _returnHP;

    }
    public void PlayerSetActive(bool setActive)//�v���C���[�̕\���ؑ�(�^�C�g���Ȃǂł�false�ɂ���)
    {
        if(setActive)
        {
            playerObject.SetActive(true);
            playerObject.transform.position = startObject.transform.position;//�v���C���[�̍��W��StartObject�Ɉړ�
        }
        else
        {
            playerObject.SetActive(false);
        }
    }
}
