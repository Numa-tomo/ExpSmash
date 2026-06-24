using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public static CountDownManager Instance;

    [SerializeField]
    private TMP_Text countDownText;

    public bool IsFinished {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        IsFinished = false;

        countDownText.text = "3";
        yield return new WaitForSeconds(1f);

        countDownText.text = "2";
        yield return new WaitForSeconds(1f);

        countDownText.text = "1";
        yield return new WaitForSeconds(1f);

        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countDownText.gameObject.SetActive(false);

        IsFinished = true;
    }
}
