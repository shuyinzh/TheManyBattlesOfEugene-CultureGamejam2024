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
    public AudioSource audioSource;

    private string apiKey =
        "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";

    private string apiUrl = "https://api.openai.com/v1/chat/completions";
    private string TTSapiUrl = "https://api.openai.com/v1/audio/speech";

    public enum characterTalking
    {
        Eugene,
        Mum,
        Granny,
        God
    }

    public enum intentType
    {
        Attack,
        Defense
    }

    public enum currentBattle
    {
        Battle1,
        Battle2
    };

    private Dictionary<currentBattle, string> extraInfo = new Dictionary<currentBattle, string>()
    {
        {
            currentBattle.Battle1,
            "This is Eugen's childhood, Eugene is battling his mother who always neglected him and is rumoured to be behind a streak of poisonings of royals"
        },
        {
            currentBattle.Battle2,
            "This is Eugen's youth, his over bearing and very religious granny wants him to become a priest but he refuses"
        }
    };

    // Function to send a prompt and receive the response
    public void GenerateTaunt(currentBattle eI)
    {
        StartCoroutine(SendOpenAIRequest(
            "I need a one liner taunt or joke from the perspective of Eugene von Savoyen, please make it up to 10 words long and don't add anything but the joke/taunt, no parenthesis, no formatting, no apostrophes, just the quote, as an added context of who to taunt and of the situation Eugen is in, use this: " +
            extraInfo[eI] +
            " Like I said, only the taunt/joke, this is very important and up to 10 words and end with three exclamation marks!",
            "echo"));
    }

    public void GenerateIntent(characterTalking cT, currentBattle cB, intentType iT)
    {
        bool requestCorrect = true;
        string attackDefend = "";
        string addedCharacterInfo = "";
        string voiceModel = "echo";

        if (iT == intentType.Attack)
        {
            attackDefend = "attack";
        }
        else if (iT == intentType.Defense)
        {
            attackDefend = "block an attack by another character";
        }
        else
        {
            requestCorrect = false;
            Debug.LogError("Unknown intent type");
        }

        switch (cT)
        {
            case characterTalking.Eugene:
                addedCharacterInfo = "Eugene von Savoyen";
                voiceModel = "echo";
                break;
            case characterTalking.Mum:
                addedCharacterInfo = "Eugene von Savoyen's mother who is rumoured to poison royals";
                voiceModel = "nova";
                break;
            case characterTalking.Granny:
                addedCharacterInfo = "Eugene von Savoyen's granny who wants Eugene to become a priest";
                voiceModel = "alloy";
                break;
            case characterTalking.God:
                addedCharacterInfo = "God, who, like Eugene von Savoyen's granny, wants Eugene to become a priest";
                voiceModel = "onyx";
                break;
        }

        if (requestCorrect)
        {
            StartCoroutine(SendOpenAIRequest(
                "I need a one-liner quip for a video game character stating the game action they are about to perform. The game is about Eugene von Savoyen's battle against his mum, grandma and god. You are " +
                addedCharacterInfo + " and you are about to" +
                attackDefend +
                " please make it up to 10 words long and don't add anything but the one-liner, no parenthesis, not formatting, no apostrophes, just the one-liner, as and added context of the situation the game is portraying right now, use this: "
                + extraInfo[cB] +
                " Like I said, only the one-liner, this is very important and up to 10 words only, no quotation marks! And you have to state clearly what the character is about to do i.e. blocking or attacking",
                voiceModel));
        }
    }

    // Coroutine to send the request
    private IEnumerator SendOpenAIRequest(string prompt, string voiceModel)
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
            GenerateSpeech(generatedText, voiceModel);
        }
    }

    // Function to generate speech and play it
    public void GenerateSpeech(string text, string voiceModel)
    {
        StartCoroutine(SendTTSRequest(text, voiceModel));
    }

    // Coroutine to send the TTS request and handle the response
    private IEnumerator SendTTSRequest(string inputText, string voiceModel)
    {
        // Create the JSON body with the necessary parameters
        string jsonBody = "{\"model\":\"" + model + "\", \"voice\":\"" + voiceModel + "\", \"input\":\"" + inputText + "\"}";

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

    private void Start()
    {
        GenerateIntent(characterTalking.Mum, currentBattle.Battle1, intentType.Defense);
    }
}