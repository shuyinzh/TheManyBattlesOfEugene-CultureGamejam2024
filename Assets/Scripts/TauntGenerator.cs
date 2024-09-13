using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;

public class TauntGenerator : MonoBehaviour
{
    private string voice = "echo"; // Voice selection, modify as necessary
    private string model = "tts-1";
    private string currentTaunt = "";
    public AudioSource audioSource;

    private string apiKey =
        "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";

    private string apiUrl = "https://api.openai.com/v1/chat/completions";
    private string TTSapiUrl = "https://api.openai.com/v1/audio/speech";


    public enum currentBattle
    {
        Battle1,
        Battle2,
        Battle3,
        Battle4,
        Battle5
    };

    private Dictionary<currentBattle, string> extraInfo = new Dictionary<currentBattle, string>()
    {
        {
            currentBattle.Battle1,
            "This is Eugen's childhood, you are battling your mother who always neglected you and is rumoured to be behind a streak of poisonings of royals, you are taunting your mother"
        },
        {
            currentBattle.Battle2,
            "This is Eugen's youth, your over bearing and very religious granny wants you to become a priest but you refuse, you are taunting your granny and god"
        },
        {
            currentBattle.Battle3,
            "This is after your brother, Ludwig's, death. You want to take over the regiment he lead in Passau but first you have to prove yourself in the battle over Kahlenberg, you are taunting the opposing army"
        },
        {
            currentBattle.Battle4,
            "This is the Battle of Zenta, the ottoman troops are crossing a river and you have to hold them back, you are taunting the ottoman troops"
        },
        {
            currentBattle.Battle5,
            "This is the battle against Kaiser Leopold the first, who doesn't want you to get this new military rank you desire, you want his son, Jospeh to take over and give you the rank, you are taunting Kaiser Leopold I."
        }
    };

    // Function to send a prompt and receive the response
    public void GenerateTaunt(currentBattle eI)
    {
        currentTaunt = "";

        StartCoroutine(SendOpenAIRequest(
            "I need a one liner taunt or joke from the perspective of Eugene von Savoyen, please make it up to 10 words long and don't add anything but the joke/taunt, no parenthesis, no formatting, no apostrophes, just the quote, as an added context of the situation Eugen is in, use this: " +
            extraInfo[eI] +
            " Like I said, only the taunt/joke, this is very important and up to 10 words and end with three exclamation marks!"));
    }

    // Coroutine to send the request
    private IEnumerator SendOpenAIRequest(string prompt)
    {
        // Create the request data
        var jsonBody = new JObject
        {
            { "model", "gpt-4" },
            {
                "messages", new JArray(
                    new JObject { { "role", "system" }, { "content", "You are a helpful assistant." } },
                    new JObject { { "role", "user" }, { "content", prompt } })
            }
        };

        // Convert JSON to string
        string jsonString = jsonBody.ToString();

        // Create a new UnityWebRequest
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonString);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            // Parse and use the response
            string jsonResponse = request.downloadHandler.text;
            JObject responseObj = JObject.Parse(jsonResponse);

            string generatedText = responseObj["choices"][0]["message"]["content"].ToString();
            Debug.Log("Generated Text: " + generatedText);
            currentTaunt = generatedText;
            GenerateSpeech(currentTaunt);
        }
    }

    // Function to generate speech and play it
    public void GenerateSpeech(string text)
    {
        StartCoroutine(SendTTSRequest(text));
    }

    // Coroutine to send the TTS request and handle the response
    private IEnumerator SendTTSRequest(string inputText)
    {
        // Create the JSON body with the necessary parameters
        string jsonBody = "{\"model\":\"" + model + "\", \"voice\":\"" + voice + "\", \"input\":\"" + inputText + "\"}";

        // Create UnityWebRequest for the POST method
        UnityWebRequest request = new UnityWebRequest(TTSapiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error in TTS request: " + request.error);
        }
        else
        {
            // Save the received audio data to a file
            byte[] audioData = request.downloadHandler.data;
            string filePath = Path.Combine(Application.persistentDataPath, "speech.mp3");

            File.WriteAllBytes(filePath, audioData);

            // Play the saved audio file in Unity
            StartCoroutine(PlayAudioFile(filePath));
        }
    }

    // Coroutine to play the audio file
    private IEnumerator PlayAudioFile(string filePath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error loading audio file: " + www.error);
            }
            else
            {
                // Load and play the audio clip
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}