using UnityEngine;
using DG.Tweening;
public class BallTakeAni : MonoBehaviour
{
    [SerializeField] private Transform _redUI;
    [SerializeField] private Transform _greenUI;
    [SerializeField] private Transform _blueUI;
    [SerializeField] private Material _green;
    [SerializeField] private Material _red;
    [SerializeField] private Material _blue;
    public void BallUIAnimation (GameObject other)
    {
        Material ballColor = other.GetComponent<MeshRenderer>().sharedMaterial;
        if (ballColor==_green)
        {
            _greenUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
            {
                _greenUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
            });
        }
        else if (ballColor == _red)
        {
            _redUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
            {
                _redUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
            });
        }
        else if (ballColor == _blue)
        {
            _blueUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
            {
                _blueUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
            });
        }
    }
    public void TakeExtraBall()
    {
        _greenUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
        {
            _greenUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
        });

        _redUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
        {
            _redUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
        });

        _blueUI.DOScale(new Vector3(.9f, .9f, .9f), .5f).OnComplete(() =>
        {
            _blueUI.DOScale(new Vector3(.7f, .7f, .7f), .5f);
        });
    }
}