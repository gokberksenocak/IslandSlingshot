using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sounds _sounds;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _inputPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private GameObject _slingTutorialPanel;
    [SerializeField] private GameObject _examplePanelPos;
    [SerializeField] private Image _timerIcon;
    [SerializeField] private Image _timerBG;
    [SerializeField] private Transform _timerLastPos;
    [SerializeField] private Transform _timerFirstPos;
    [SerializeField] private Animator[] _obstacleAnimators;
    [SerializeField] private TextMeshProUGUI[] _colorTexts;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _levelTextAtEnd;
    private Scene _scene;
    public Scene CurrentScene
    {
        get { return _scene; }
        set { _scene = value; }
    }
    public TextMeshProUGUI[] ColorTexts
    {
        get { return _colorTexts; }
        set { _colorTexts = value; }
    }
    public GameObject SlingTutorialPanel
    {
        get { return _slingTutorialPanel; }
        set { _slingTutorialPanel = value; }
    }
    public GameObject InputPanel 
    {
        get {return _inputPanel; }
        set {_inputPanel=value; }
    }
    public GameObject WinPanel
    {
        get { return _winPanel; }
        set { _winPanel = value; }
    }
    public GameObject LoosePanel
    {
        get { return _loosePanel; }
        set { _loosePanel = value; }
    }
    public GameObject UIPanel
    {
        get { return _uiPanel; }
        set { _uiPanel = value; }
    }
    public GameObject ExamplePanel
    {
        get { return _examplePanelPos; }
        set { _examplePanelPos = value; }
    }
    public TextMeshProUGUI LevelTextAtEnd
    {
        get {return _levelTextAtEnd; }
        set {_levelTextAtEnd=value; }
    }
    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        _levelText.text = "LEVEL " + PlayerPrefs.GetInt("LevelIndex").ToString();
    }

    public void StartGameEvents()
    {
        for (int i = 0; i < _obstacleAnimators.Length; i++)
        {
            _obstacleAnimators[i].SetBool("isStart", true);
        }
        _playerManager.IsStart = true;
        _playerManager.PlayerAnimator.SetBool("isFinish", false);
        _startPanel.SetActive(false);
        _uiPanel.SetActive(true);
    }
    public void MagnetTimer()
    {
        _timerIcon.transform.DOMove(_timerLastPos.position, .5f).OnComplete(()=> 
        {
            _timerBG.transform.position = _timerLastPos.position;
            StartCoroutine(TimeCount());
        });
    }
    IEnumerator TimeCount()
    {
        while (_timerIcon.fillAmount!=0)
        {
            yield return new WaitForSeconds(.1f);
            _timerIcon.fillAmount -= .025f;
        }
        if (_timerIcon.fillAmount == 0)
        {
            _sounds.AudioManagerSource.PlayOneShot(_sounds.MagnetEnd);
            StopCoroutine(TimeCount());
            _timerBG.transform.position = _timerFirstPos.position;
            _timerIcon.transform.position = _timerFirstPos.position;
            _timerIcon.fillAmount = 1;
        }
    }
}