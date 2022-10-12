using UnityEngine;
using System.Text;
using System.Globalization;
using System;
using System.Threading;
using UnityEngine.Windows.Speech;
using TMPro;

public class AudioInputManager : MonoBehaviour
{
  [SerializeField] DictationEngine dictationEngine;
  [Header("Components")]
  public GameObject TextHUD;
  public TextMeshProUGUI RecognitionResult;
  public TextMeshProUGUI TravaLingua;
  private int numPalavrasIguais = 0;
  private string recognitionResultString;
  private Thread startRecognitionThread = null;
  private Thread stopRecognitionThread = null;
  private static DictationRecognizer dictationRecognizer;

  private bool hasStarted = false;
  private string[] travaLinguaArray;

  private void Awake()
  {
    startRecognitionThread = new Thread(dictationEngine.StartRecognizingAudio);
    stopRecognitionThread = new Thread(dictationEngine.GetRecognizedAudio);
  }
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
      if (stopRecognitionThread.IsAlive)
      {
        stopRecognitionThread.Abort();
      }
      // dictationEngine.StartRecognizingAudio();
      startRecognitionThread.Start();
      hasStarted = true;
    }
    if (Input.GetKeyDown(KeyCode.Return) && hasStarted)
    {
      startRecognitionThread.Abort();
      stopRecognitionThread.Start();
      RecognitionResult.text = GlobalVariables.instance.resultOfRecognition;
      hasStarted = false;
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
