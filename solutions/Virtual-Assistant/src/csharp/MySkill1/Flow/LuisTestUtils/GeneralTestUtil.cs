﻿using Luis;
using Microsoft.Bot.Builder;
using MySkill1.Tests.Flow.Fakes;
using MySkill1.Tests.Flow.Utterances;
using System.Collections.Generic;

namespace MySkill1.Tests.Flow.LuisTestUtils
{
    public class GeneralTestUtil
    {
        private static Dictionary<string, IRecognizerConvert> _utterances = new Dictionary<string, IRecognizerConvert>
        {
            { GeneralUtterances.Cancel, CreateIntent(GeneralUtterances.Cancel, General.Intent.Cancel) },
            { GeneralUtterances.Escalate, CreateIntent(GeneralUtterances.Escalate, General.Intent.Escalate) },
            { GeneralUtterances.Goodbye, CreateIntent(GeneralUtterances.Goodbye, General.Intent.Goodbye) },
            { GeneralUtterances.Greeting, CreateIntent(GeneralUtterances.Greeting, General.Intent.Greeting) },
            { GeneralUtterances.Help, CreateIntent(GeneralUtterances.Help, General.Intent.Help) },
            { GeneralUtterances.Logout, CreateIntent(GeneralUtterances.Logout, General.Intent.Logout) },
            { GeneralUtterances.Next, CreateIntent(GeneralUtterances.Next, General.Intent.Next) },
            { GeneralUtterances.Previous, CreateIntent(GeneralUtterances.Previous, General.Intent.Previous) },
            { GeneralUtterances.Restart, CreateIntent(GeneralUtterances.Restart, General.Intent.Restart) },
        };

        public static MockLuisRecognizer CreateRecognizer()
        {
            var recognizer = new MockLuisRecognizer(defaultIntent: CreateIntent(string.Empty, General.Intent.None));
            recognizer.RegisterUtterances(_utterances);
            return recognizer;
        }

        public static General CreateIntent(string userInput, General.Intent intent)
        {
            var generalIntent = new General
            {
                Text = userInput,
                Intents = new Dictionary<General.Intent, IntentScore>()
            };

            generalIntent.Intents.Add(intent, new IntentScore() { Score = 0.9 });

            generalIntent.Entities = new General._Entities
            {
                _instance = new General._Entities._Instance()
            };

            return generalIntent;
        }
    }
}