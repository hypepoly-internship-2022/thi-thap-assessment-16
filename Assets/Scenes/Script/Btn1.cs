using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Btn1 : MonoBehaviour
{
    [SerializeField] private Transform cubeA;
    [SerializeField] private Transform cubeB;
    [SerializeField] private float timeA;
    [SerializeField] private float timeB;
    [SerializeField] private Button button2;

    private Vector3 cubeBPos;
    private Vector3 cubeBScale;



    // Start is called before the first frame update
    void Start()
    {
        cubeBPos = cubeB.position;
        cubeBScale = cubeB.localScale;
    }
    private void Action()
    {
       cubeA.DOMove(new Vector3(cubeBPos.x + 3, cubeBPos.y, 0), timeA).SetEase(Ease.InOutSine).OnComplete(() => {
            cubeA.DOMove(new Vector3(cubeBPos.x, cubeBPos.y, 0), 2).SetEase(Ease.InOutSine).OnComplete(() => {
                cubeB.DOScale(cubeBScale * 2, timeB).SetEase(Ease.InOutSine).OnComplete(() => {
                    cubeB.DOScale(cubeBScale, 2).SetEase(Ease.InOutSine).OnComplete(() => {
                        button2.GetComponent<Button>().interactable = false;
                        this.GetComponent<Image>().DOFade(0, 2f);
                        button2.GetComponent<Image>().DOFade(0, 2f);
                    });
                });
            });
        });

    }

    // Update is called once per frame
    void Update()
    {
        // transform.DOMove(new Vector3(10,0,0),2).SetEase(Ease.InOutSine);
    }
    public void OnClickBtn1()
    {
        this.GetComponent<Button>().interactable = false;
        Action();
    }
}
