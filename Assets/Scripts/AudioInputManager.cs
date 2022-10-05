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
  [SerializeField] DictationEngine dictationEngine;
  [Header("Components")]
  public GameObject TextHUD;
  public TextMeshProUGUI RecognitionResult;
  public TextMeshProUGUI TravaLingua;
  private int numPalavrasIguais = 0;

  private bool hasStarted = false;
  private string[] travaLinguaArray;
  // Start is called before the first frame update
  void Start()
  {
    travaLinguaArray = TravaLingua.text.Split(" ");
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && !hasStarted)
    {
      dictationEngine.StartDictationEngine();
      hasStarted = true;
    }
    if (Input.GetKeyDown(KeyCode.Return))
    {
      RecognitionResult.text = dictationEngine.resultOfRecognition;
      string[] recognitionResultArray = RecognitionResult.text.Split(" ");
      for (int i = 0; i < travaLinguaArray.Length; i++)
      {
        if (i >= recognitionResultArray.Length)
        {
          break;
        }
        if (String.Equals(RemoveAccents(recognitionResultArray[i]).ToLower(), RemoveAccents(travaLinguaArray[i]).ToLower()))
        {
          numPalavrasIguais++;
        }
      }
      //   Debug.Log(dictationEngine.resultOfRecognition);
      Debug.Log("Número de palavras iguais = " + numPalavrasIguais);
      numPalavrasIguais = 0;
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
