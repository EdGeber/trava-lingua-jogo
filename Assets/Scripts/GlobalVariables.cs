using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
  public static GlobalVariables instance;
  public DictationRecognizer dictationRecognizer;
  public string resultOfRecognition;
  public string hypothesisOfRecognition;

  public void DictationRecognizer_OnDictationHypothesis(string text)
  {
    // Debug.Log("Dictation hypothesis: " + text);
    hypothesisOfRecognition = text;
  }
  private void DictationRecognizer_OnDictationComplete(DictationCompletionCause completionCause)
  {
    switch (completionCause)
    {
      case DictationCompletionCause.TimeoutExceeded:
      case DictationCompletionCause.PauseLimitExceeded:
      case DictationCompletionCause.Canceled:
      case DictationCompletionCause.Complete:
        // Restart required
        CloseDictationEngine();
        StartRecognizingAudio();
        break;
      case DictationCompletionCause.UnknownError:
      case DictationCompletionCause.AudioQualityFailure:
      case DictationCompletionCause.MicrophoneUnavailable:
      case DictationCompletionCause.NetworkFailure:
        // Error
        CloseDictationEngine();
        break;
    }
  }
  public void DictationRecognizer_OnDictationResult(string text, ConfidenceLevel confidence)
  {
    // Debug.Log("Dictation result: " + text);
    resultOfRecognition = text;
  }
  private void DictationRecognizer_OnDictationError(string error, int hresult)
  {
    Debug.Log("Dictation error: " + error);
  }

  private void OnApplicationQuit()
  {
    CloseDictationEngine();
  }
  public void StartRecognizingAudio()
  {
    dictationRecognizer = new DictationRecognizer();
    dictationRecognizer.DictationHypothesis += DictationRecognizer_OnDictationHypothesis;
    dictationRecognizer.DictationResult += DictationRecognizer_OnDictationResult;
    dictationRecognizer.DictationComplete += DictationRecognizer_OnDictationComplete;
    dictationRecognizer.DictationError += DictationRecognizer_OnDictationError;
    dictationRecognizer.Start();
  }
  private void CloseDictationEngine()
  {
    if (dictationRecognizer != null)
    {
      dictationRecognizer.DictationHypothesis -= DictationRecognizer_OnDictationHypothesis;
      dictationRecognizer.DictationComplete -= DictationRecognizer_OnDictationComplete;
      dictationRecognizer.DictationResult -= DictationRecognizer_OnDictationResult;
      dictationRecognizer.DictationError -= DictationRecognizer_OnDictationError;
      if (dictationRecognizer.Status == SpeechSystemStatus.Running)
      {
        dictationRecognizer.Stop();
      }
      dictationRecognizer.Dispose();
    }
  }

  public string GetRecognizedAudio()
  {
    CloseDictationEngine();
    return hypothesisOfRecognition;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
