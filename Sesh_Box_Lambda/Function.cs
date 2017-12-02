using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public const string INVOCATION_NAME = "Sesh Box";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {

            var requestType = input.GetRequestType();
            if (requestType == typeof(IntentRequest))
            {
                return MakeSkillResponse(
                        outputSpeech: $"Hey there, welcome to the Sesh Box. Let's get ready to party",
                        shouldEndSession: true);
            }
            else
            {
                return MakeSkillResponse(
                        outputSpeech: $"I don't know how to handle this intent. Please say something like Alexa, ask {INVOCATION_NAME}.",
                        shouldEndSession: true);
            }
        }


        private SkillResponse MakeSkillResponse(string outputSpeech,
            bool shouldEndSession,
            string repromptText = "Just say, tell me about Picolo. To exit, say, exit.")
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new PlainTextOutputSpeech { Text = outputSpeech }
            };

            if (repromptText != null)
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
