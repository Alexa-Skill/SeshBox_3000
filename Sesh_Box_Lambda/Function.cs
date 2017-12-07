using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using System;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Sesh_Box_Lambda
{
    public class Function
    {
        //private static bool GAME_HELP = false;
        //private static bool VERSION_HELP = false;
        // Name to start the skill
        private const string INVOCATION_NAME = "Sesh Box";
        private static bool Help_requested = false;
        private static bool Game_selecting= false;
        private static bool Stop_requested = false;
        private static bool Leave_requested = false;

        string GAME_QUESTED = null;
        string PARTICIPENTS_REQUESTED = null;
        string VERSION_REQUESTED = null;

        PicoloRules newPicoloRules = new PicoloRules();
        string picoloRule;

        /// <summary>
        /// Main FXN handler for the skill
        /// TODO: Implement a menu type system. May require separation of files.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns>
        /// MakeSkilResponse which is passed a string to be spoken speech
        /// </returns>

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            // check what type of a request it is like an IntentRequest or a LaunchRequest
            var requestType = input.GetRequestType();
            



            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = input.Request as IntentRequest;
                GAME_QUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                PARTICIPENTS_REQUESTED = intentRequest?.Intent?.Slots["Participents"].Value;
                VERSION_REQUESTED = intentRequest?.Intent?.Slots["Version"].Value;

                switch (intentRequest.Intent.Name)
                {
                    case "SeshBoxIntent":
                        Game_selecting = true;
                        return Response(
                        shouldEndSession: false,
                        outputSpeech: $"Start of the skill, and also a random game selection",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: null,
                        cardText: $"Start of the skill, and also a random game selection",
                        gameSelected: null,
                        participents: null,
                        version: null
                        );
                    case "StartGameIntent":
                        newPicoloRules.GameVersion = GAME_QUESTED;
                        Game_selecting = true;
                        return Response(
                        shouldEndSession: false,
                        outputSpeech: $"Starting a specific Game",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: $"Let's play!",
                        cardText: $"Starting a specific Game",
                        gameSelected: GAME_QUESTED,
                        participents: PARTICIPENTS_REQUESTED,
                        version: VERSION_REQUESTED
                        );


                    case "AMAZON.HelpIntent":
                        Help_requested = true;
                        return Response(
                        shouldEndSession: true,
                        outputSpeech: $"If you're stuck, then so am I",
                        repromptSpeech: null,
                        cardTitle: $"Help section",
                        cardText: $"Wellcome to Sesh Box 3000",
                        gameSelected: GAME_QUESTED,
                        participents: PARTICIPENTS_REQUESTED,
                        version: VERSION_REQUESTED
                        );

                    case "TotallyLostIntent":
                        return Response(
                        shouldEndSession: false,
                        outputSpeech: $"Looks like you're totally lost. There are 3 game modes, Picolo, Truth or Dare, and Never Have I Ever",
                        repromptSpeech: $"Ready to pick a game. Simply say " + INVOCATION_NAME + " start a game of Picolo",
                        cardTitle: null,
                        cardText: $"/n",
                        gameSelected: null,
                        participents: null,
                        version: null);

                    case "AMAZON.CancelIntent":
                        if (Stop_requested) {
                            Leave_requested = true;
                        }
                        Stop_requested = true;
                        return Response(
                        shouldEndSession: true,
                        outputSpeech: $"woah, Hold up",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: null,
                        cardText: $"Wellcome to Sesh Box 3000",
                        gameSelected: null,
                        participents: null,
                        version: null
                        );

                    case "ConfrimIntent":
                        return Response(
                        shouldEndSession: true,
                        outputSpeech: $"Sure thing, I'll continue",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: null,
                        cardText: $"Wellcome to Sesh Box 3000",
                        gameSelected: null,
                        participents: null,
                        version: null
                        );

                    case "NextIntent":
                        return Response(
                        shouldEndSession: true,
                        outputSpeech: $"Sure thing, moving to next card",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: null,
                        cardText: $"Wellcome to Sesh Box 3000",
                        gameSelected: null,
                        participents: null,
                        version: null
                        );

                }

                return Response(
                    shouldEndSession: true,
                    outputSpeech: "What are you looking to do ?" + intentRequest.ToString(),
                    repromptSpeech: $"If you're stuck, just say help",
                    cardTitle: null,
                    cardText: "What are you looking to do ?",
                    gameSelected: null,
                    participents: null,
                    version: null
                    );
            }
            else if (requestType == typeof(Alexa.NET.Request.Type.LaunchRequest))
            {
                return Response(
                    shouldEndSession: false,
                    outputSpeech: $"Wellcome to Sesh Box 3000",
                    repromptSpeech: $"If you're stuck, just say help",
                    cardTitle: $"Welcome",
                    cardText: $"Wellcome to Sesh Box 3000",
                    gameSelected: null,
                    participents: null,
                    version: null
                    );
            }
            else
            {
                return Response(
                    shouldEndSession: true,
                    outputSpeech: $"I don't know how to resolve that intent",
                    repromptSpeech: $"If you're stuck, just say help",
                    cardTitle: null,
                    cardText: $"I've no idea what's going on !?",
                    gameSelected: null,
                    participents: null,
                    version: null
                    );
            }
        }


        /*public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
         {

             var requestType = input.GetRequestType();

             if (requestType == typeof(IntentRequest))
             {
                 var intentRequest = input.Request as IntentRequest;
                 var GAME_QUESTED = intentRequest?.Intent?.Slots["Games"].Value;

                 if (intentRequest.Equals("LaunchIntent")) {
                     return LaunchSkill(true,$"Welcom to the Sesh Box 3000", $"Welcom to the Sesh Box 3000");
                 }
                 if (GAME_QUESTED == null)
                 {
                     context.Logger.LogLine($"The game you asked for was not undersif tood or not part of the skill.");
                     return MakeSkillResponse(
                         outputSpeech: $"I'm sorry, but I didn't understand the game you were asking for. Please ask again.", 
                         shouldEndSession: false,
                         gameSelected: null,
                         repromptText: null
                         );
                 }

                 return MakeSkillResponse(
                         outputSpeech: $"You'd like more information about {GAME_QUESTED}",
                         shouldEndSession: true,
                         gameSelected: GAME_QUESTED.ToString(),
                         repromptText: null
                         );


             }
             else
             {
                 return MakeSkillResponse(
                         outputSpeech: $"I don't know how to handle this intent. Please say something like Alexa, ask {INVOCATION_NAME}.",
                         shouldEndSession: true,
                         gameSelected: null,
                         repromptText: null);
             }
             */

        private SkillResponse Response(bool shouldEndSession, string outputSpeech, string repromptSpeech, string cardTitle, string cardText, string gameSelected, string participents, string version)
        {

            if (Game_selecting) {
                if (gameSelected != null)
                {
                    outputSpeech = "So, playing " + gameSelected;
                }
                else if (gameSelected == null)
                {
                    outputSpeech = "First let's see what game you'd like to play ?";
                    shouldEndSession = false;
                    // gameSelected = to returned game value from new response
                    repromptSpeech = "If you're stuck just ask, what games can I play";
                }
                if (participents != null)
                {
                    outputSpeech += " with " + Int32.Parse(participents) + " players";
                }
                else if (participents == null)
                {
                    outputSpeech += "So then, how many people are playing";
                    shouldEndSession = false;
                    // participents = to returned game value from new response
                    repromptSpeech = "Just say how many people are playing.";
                }
                if (version != null)
                {
                    picoloRule = newPicoloRules.Rules();
                    outputSpeech += " and playing the " + version + "version. First rule: " + picoloRule;
                }
                else if (version == null)
                {
                    outputSpeech += "Now, what version of the game do you wanna play";
                    shouldEndSession = false;
                    // participents = to returned game value from new response
                    repromptSpeech = "If you're stuck, just ask what versions of the game I can play";
                }
            }

            if (Help_requested) {
                if (gameSelected != null)
                {
                    outputSpeech += "The Games availble are, Truth or Dare, Never Have I Ever, or Picolo";
                    repromptSpeech += "If you need further help, you can ask about each game individualy";
                }
                else if (participents != null)
                {
                    outputSpeech += "I need to know who's playing.Please say each name slowly and clearly";
                    repromptSpeech += "This isn't that hard. Please let me know who's playing";
                }
                else if (version != null) {
                    outputSpeech += "The versions availible to you are, Getting Started, Getting Silly, War, Caliente"; // TODO Pull this from a corresponding list of versions 
                    repromptSpeech += "Still not sure. I'd sugested Caliente"; //TODO select a random game
                }
            }

            
            if (Stop_requested) {
                repromptSpeech += "Just asking one last Time, or else I'll just go back now.";
                if (gameSelected != null)
                {
                    outputSpeech += "Are you sure you want to quit back to the main menu?";
                    GAME_QUESTED = null;
                }
                else if (participents != null)
                {
                    outputSpeech += "Are you sure you want to go back to the game selection";
                    PARTICIPENTS_REQUESTED = GAME_QUESTED = null;
                }
                else if (version != null)
                {
                    outputSpeech += "Are you sure you want to go back and re-enter the participents' names ?"; 
                    VERSION_REQUESTED = PARTICIPENTS_REQUESTED = null;
                }
                // nesting this if statement to check if the user 
                // Want to fully leave the app
                if (Leave_requested) {
                    outputSpeech += "Are you sure you want to quite the skill";
                    repromptSpeech += "Just checking one last time. You sure you wnat to leave";
                }
            }

            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech },
                Card = new StandardCard { Title = cardTitle, Content = cardText },
                Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptSpeech } }
            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            Help_requested = false;
            return skillResponse;
        }

        private string getGameVerison() {
            string gameversion = "";
            return gameversion;
        }

        private SkillResponse FurtherResponse(bool shouldEndSession, string outputSpeech, string cardText) {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech },
                Card = new StandardCard { Title = "Welcome", Content = cardText }

            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            return skillResponse;
        }

        private SkillResponse GameResponse(bool shouldEndSession, string outputSpeech, string cardText, int round)
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech },
                Card = new StandardCard { Title = "Welcome", Content = cardText }

            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };

            return skillResponse;
        }


        /// <summary>
        /// FXN to deal with creating an output speech method
        /// </summary>
        /// <param name="outputSpeech"></param>
        /// <param name="shouldEndSession"></param>
        /// <param name="repromptText"></param>
        /// <returns></returns>
        private SkillResponse MakeSkillResponse(
            string outputSpeech,
            bool shouldEndSession,
            string gameSelected,
            string repromptText)
        {
            if (outputSpeech == null)
            {
                throw new System.ArgumentNullException(nameof(outputSpeech));
            }

            if (string.IsNullOrWhiteSpace(gameSelected))
            {
                throw new System.ArgumentException("message", nameof(gameSelected));
            }

            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech },
                Card = new StandardCard { Title = gameSelected, Content = "Here listen to what alexa has to say about " + gameSelected.ToString() }
            };

            if (repromptText == null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = "Just say, tell me about " + gameSelected.ToString() + ". To exit, say, exit." } };
            }
            else if (repromptText != null)
            {
                response.Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptText } };
            }


            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResponse;
        }
    }

    enum GameStatus{
        NOTHINGSELECED,
        GAMESELECTED,
        PARTICPENTSSELECTED,
        VERSIONSELECTED
    };
}
