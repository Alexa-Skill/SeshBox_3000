using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Sesh_Box_Lambda
{
    public class Function
    {
        // Name to start the skill
        public const string INVOCATION_NAME = "Sesh Box";

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

                switch (intentRequest.Intent.Name)
                {
                    case "SeshBoxIntent":
                        return BasicResponse(
                        shouldEndSession: true,
                        outputSpeech: $"Start of the skill, and also a random game selection",
                        cardText: $"Start of the skill, and also a random game selection"
                        );
                    case "StartGameIntent":
                        return BasicResponse(
                        shouldEndSession: true,
                        outputSpeech: $"Starting a specific Game",
                        cardText: $"Starting a specific Game"
                        );


                    case "AMAZON.HelpIntent":
                        return BasicResponse(
                        shouldEndSession: true,
                        outputSpeech: $"If you're stuck, then so am I",
                        cardText: $"Wellcome to Sesh Box 3000"
                        );
                    case "AMAZON.CancelIntent":
                        return BasicResponse(
                shouldEndSession: true,
                outputSpeech: $"woah, Hold up",
                cardText: $"Wellcome to Sesh Box 3000"
                );

                    case "ConfrimIntent":
                        return BasicResponse(
                shouldEndSession: true,
                outputSpeech: $"Sure thing, I'll continue",
                cardText: $"Wellcome to Sesh Box 3000"
                );

                    case "NextIntent":
                        return BasicResponse(
                shouldEndSession: true,
                outputSpeech: $"Sure thing, moving to next card",
                cardText: $"Wellcome to Sesh Box 3000"
                );


                }

                return BasicResponse(
                    shouldEndSession: true,
                    outputSpeech: "What are you looking to do ?" + intentRequest.ToString(),
                    cardText: "What are you looking to do ?"
                    );
            }
            else if (requestType == typeof(Alexa.NET.Request.Type.LaunchRequest))
            {
                return BasicResponse(
                    shouldEndSession: true,
                    outputSpeech: $"Wellcome to Sesh Box 3000",
                    cardText: $"Wellcome to Sesh Box 3000"
                    );
            }
            else
            {
                return BasicResponse(
                    shouldEndSession: true,
                    outputSpeech: $"I don't know how to resolve that intent",
                    cardText: "I've no idea what's going on !?"
                    );
            }
        }


        /*public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
         {

             var requestType = input.GetRequestType();

             if (requestType == typeof(IntentRequest))
             {
                 var intentRequest = input.Request as IntentRequest;
                 var gameRequested = intentRequest?.Intent?.Slots["Games"].Value;

                 if (intentRequest.Equals("LaunchIntent")) {
                     return LaunchSkill(true,$"Welcom to the Sesh Box 3000", $"Welcom to the Sesh Box 3000");
                 }
                 if (gameRequested == null)
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
                         outputSpeech: $"You'd like more information about {gameRequested}",
                         shouldEndSession: true,
                         gameSelected: gameRequested.ToString(),
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

        private SkillResponse BasicResponse(bool shouldEndSession, string outputSpeech, string cardText)
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
}
