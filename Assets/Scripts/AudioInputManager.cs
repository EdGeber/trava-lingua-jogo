using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Globalization;
using System;
using TMPro;

public class AudioInputManager : MonoBehaviour
{
  [SerializeField] public DictationEngine dictationEngine;
  [Header("Components")]
  public GameObject TextHUD;
  public TextMeshProUGUI RecognitionHypothesis;
  public TextMeshProUGUI TravaLingua;
  private int numPalavrasIguais = 0;
  public float correctWordsRatio = 0.0f;
  private bool startRecognising = false;
  private float timer = 0.0f;
  public bool StartRecognising
  {
    get { return startRecognising; }
    set { startRecognising = value; }
  }

  private string[] travaLinguaArray;
  private bool gameIsPaused = PauseBehaviour.GameIsPaused;
  // Start is called before the first frame update
  void Start()
  {
    dictationEngine.StartDictationEngine();
  }

  // Update is called once per frame
  void Update()
  {

    if (!gameIsPaused)
    {
      if (startRecognising)
      {
        timer = timer + Time.deltaTime;
        // DO SOMETHING
        if (timer >= MonoInstance.recognitionDelay)
        {
          travaLinguaArray = TravaLingua.text.Split(" ");
          RecognitionHypothesis.text = dictationEngine.resultOfHypotesis;
          string[] recognitionHypothesisArray = RecognitionHypothesis.text.Split(" ");
          for (int i = 0; i < travaLinguaArray.Length; i++)
          {
            if (i >= recognitionHypothesisArray.Length)
            {
              break;
            }
            if (String.Equals(RemoveAccents(recognitionHypothesisArray[i]).ToLower(), RemoveAccents(travaLinguaArray[i]).ToLower()))
            {
              numPalavrasIguais++;
            }
          }
          //   Debug.Log(dictationEngine.resultOfRecognition);
          //Debug.Log("Número de palavras iguais = " + numPalavrasIguais);
          correctWordsRatio = (float)numPalavrasIguais / (float)travaLinguaArray.Length;
          timer = 0.0f;
          numPalavrasIguais = 0;
          startRecognising = false;
        }
      }

    }
  }

  public static string RemoveAccents(string text)
  {
    StringBuilder sbReturn = new StringBuilder();
    var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
    foreach (char letter in arrayText)
    {
      if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
        sbReturn.Append(letter);
    }
    return sbReturn.ToString();
  }
}
