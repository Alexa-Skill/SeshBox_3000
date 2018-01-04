using Amazon.Lambda.Core;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using System;
using System.Collections.Generic;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Sesh_Box_Lambda
{
    public class Function
    {
        // Name to start the skill
        private const string INVOCATION_NAME = "Sesh Box";
        private static bool Help_requested = false;
        private static bool Totally_Lost = false;
        private static bool Game_selecting= false;
        private static bool Stop_requested = false;
        private static bool Leave_requested = false;
        private static bool Confirm_requested = false;
        private static bool Next_requested = false;

        string GAME_REQUESTED = null;
        string PARTICIPENTS_REQUESTED = null;
        string VERSION_REQUESTED = null;
        string PEOPLE_REQUESTED = null;
        string PERSON_REQUESTED = null;
        string[] names = null;

        //PicoloRules newPicoloRules = new PicoloRules();
        //string picoloRule;

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
                
                //GAME_REQUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                //PARTICIPENTS_REQUESTED = intentRequest?.Intent?.Slots["Participents"].Value;
                //VERSION_REQUESTED = intentRequest?.Intent?.Slots["Version"].Value;

                switch (intentRequest.Intent.Name)
                {
                    case "SeshBoxIntent":
                        context.Logger.LogLine($"I'm in the SeshBoxIntent section");
                        return Response(
                        shouldEndSession: false,
                        outputSpeech: $"Welcome to Sesh Box 3000",
                        repromptSpeech: $"If you're stuck, just say help",
                        cardTitle: $"Skill Menu",
                        cardText: $"Wellcome to The Sesh-Box 3000 \n" +
                        $"There are three games you can play: \n " +
                        $"Truth or Dare \n " +
                        $"Never Have I ever \n " +
                        $"Picolo \n\n" +
                        $"Each game has a few diffent versions \n" +
                        $"Don't be afraid to ask for help",
                        gameSelected: null,
                        participents: null,
                        version: null
                        );
                        
                    case "StartGameIntent":
                        //newPicoloRules.GameVersion = GAME_QUESTED;
                        GAME_REQUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                        Game_selecting = true;
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: $"Starting a game of " + GAME_REQUESTED,
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"Let's play!",
                            cardText: $"Starting a " + GAME_REQUESTED,
                            gameSelected: GAME_REQUESTED,
                            participents: null,
                            version: null
                            );

                    case "StartGameVersionIntent":
                        //newPicoloRules.GameVersion = GAME_QUESTED;
                        GAME_REQUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                        VERSION_REQUESTED = intentRequest?.Intent?.Slots["Version"].Value;
                        Game_selecting = true;
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: $"Starting a game of " + GAME_REQUESTED + " " + VERSION_REQUESTED + " version",
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"Let's play!",
                            cardText: $"Starting a " + GAME_REQUESTED + " " + VERSION_REQUESTED + " version",
                            gameSelected: GAME_REQUESTED,
                            participents: null,
                            version: VERSION_REQUESTED
                            );

                    case "StartGameParticipentsIntent":
                        //newPicoloRules.GameVersion = GAME_QUESTED;
                        GAME_REQUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                        PARTICIPENTS_REQUESTED = intentRequest?.Intent?.Slots["Participents"].Value;
                        Game_selecting = true;
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: $"Starting a game of " + GAME_REQUESTED + " with " + PARTICIPENTS_REQUESTED + " people,",
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"Let's play!",
                            cardText: $"Starting a " + GAME_REQUESTED + " with " + PARTICIPENTS_REQUESTED + " people,",
                            gameSelected: GAME_REQUESTED,
                            participents: PARTICIPENTS_REQUESTED,
                            version: null
                            );

                    case "StartGameSpecificIntent":
                        //newPicoloRules.GameVersion = GAME_QUESTED;
                        GAME_REQUESTED = intentRequest?.Intent?.Slots["Games"].Value;
                        PARTICIPENTS_REQUESTED = intentRequest?.Intent?.Slots["Participents"].Value;
                        VERSION_REQUESTED = intentRequest?.Intent?.Slots["Version"].Value;
                        Game_selecting = true;
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: $"Starting a game of " + GAME_REQUESTED + ", " + VERSION_REQUESTED + " version, with " + PARTICIPENTS_REQUESTED + " people,",
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"Let's play!",
                            cardText: $"Starting a " + GAME_REQUESTED + ", " + VERSION_REQUESTED + " version, with " + PARTICIPENTS_REQUESTED + " people,",
                            gameSelected: GAME_REQUESTED,
                            participents: PARTICIPENTS_REQUESTED,
                            version: VERSION_REQUESTED
                            );

                    case "ParticipentsIntent":
                        PARTICIPENTS_REQUESTED = intentRequest?.Intent?.Slots["Participents"].Value;
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: $"Got it " + PARTICIPENTS_REQUESTED.ToString() + " people are playing, who are they",//Move this last bit to the response builder
                            //ssmlOutputSpeech: $"<speak>Okay, so " + PARTICIPENTS_REQUESTED + " are playing <break time = \"3s\" />So what are there names ?</ speak > ",
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"ParticipentsIntent",
                            cardText: $"ParticipentsIntent",
                            gameSelected: null,
                            participents: null,
                            version: null
                            );

                    case "NamesIntent":
                        PERSON_REQUESTED = intentRequest?.Intent?.Slots["Persons"].Value;
                        names = PERSON_REQUESTED.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        string outspeach = $"Got it, ";
                        for (int i = 0; i < names.Length; i++)
                        {
                            if (i == names.Length - 1) {
                                outspeach += "and " + names[i] + " are playing";
                            }
                            else
                            {
                                outspeach += names[i] + ", ";
                            }
                        }
                       
                        return Response(
                            shouldEndSession: false,
                            outputSpeech: outspeach,
                            //ssmlOutputSpeech: $"<speak>Okay, so " + PARTICIPENTS_REQUESTED + " are playing <break time = \"3s\" />So what are there names ?</ speak > ",
                            repromptSpeech: $"If you're stuck, just say help",
                            cardTitle: $"ParticipentsIntent",
                            cardText: $"ParticipentsIntent",
                            gameSelected: null,
                            participents: null,
                            version: null
                            );


                        /*
                          case "AMAZON.HelpIntent":
                              context.Logger.LogLine($"I'm in the HelpIntent section");
                              Help_requested = true;
                              return Response(
                              shouldEndSession: false,
                              outputSpeech: null,
                              repromptSpeech: null,
                              cardTitle: $"Help section",
                              cardText: $"Here will be all the help text",
                              gameSelected: null,
                              participents: null,
                              version: null
                              );

                          case "TotallyLostIntent":
                              context.Logger.LogLine($"I'm in the TotallyLostIntent section");
                              Totally_Lost = true;
                              return Response(
                              shouldEndSession: false,
                              outputSpeech: $"Looks like you're totally lost !",
                              repromptSpeech: $"You still there ?",
                              cardTitle: $"Totally Lost",
                              cardText: $"Text will be added",
                              gameSelected: GAME,
                              participents: PARTICIPENTS,
                              version: null
                              );
                          /*
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
                              cardText: null,
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
                              cardText: null,
                              gameSelected: null,
                              participents: null,
                              version: null
                              );

                          case "NextIntent":
                              Next_requested = true;
                              return Response(
                              shouldEndSession: true,
                              outputSpeech: $"Sure thing, moving to next card",
                              repromptSpeech: $"If you're stuck, just say help",
                              cardTitle: null,
                              cardText: null,
                              gameSelected: null,
                              participents: null,
                              version: null
                              );
                              */
                }

                return Response(
                    shouldEndSession: true,
                    outputSpeech: "What are you looking to do ?" + intentRequest.ToString(),
                    repromptSpeech: $"If you're stuck, just say help",
                    cardTitle: null,
                    cardText: null,
                    gameSelected: null,
                    participents: null,
                    version: null
                    );
            }
            else if (requestType == typeof(Alexa.NET.Request.Type.LaunchRequest))
            {
                return Response(
                    shouldEndSession: false,
                    outputSpeech: $"Welcome to Sesh Box 3000",
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
                context.Logger.LogLine($"The thing what you asked for was not understood or not part of the skill.");
                return Response(
                    shouldEndSession: true,
                    outputSpeech: $"I don't know how to resolve that intent",
                    repromptSpeech: $"If you're stuck, just say help",
                    cardTitle: $"Whuuut",
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

        /// <summary>
        /// All in one FXN to deal with creating an output speech method
        /// </summary>
        /// <param name="shouldEndSession"></param>
        /// <param name="outputSpeech"></param>
        /// <param name="repromptSpeech"></param>
        /// <param name="cardTitle"></param>
        /// <param name="cardText"></param>
        /// <param name="gameSelected"></param>
        /// <param name="participents"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        private SkillResponse Response(bool shouldEndSession, string outputSpeech, string repromptSpeech, string cardTitle, string cardText, string gameSelected, string participents, string version)
        {
            

            /// Voice Testing 
            /// Section 1: Yes. But still asks for section 2&3 at the same time 
            /// Section 2: No
            /// Section 3: Yed
            if (Game_selecting) {
                Game_selecting = false;
                if (gameSelected != null)
                {
                    outputSpeech = "So, playing " + gameSelected + ", ";
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
                    outputSpeech += " and how many people are playing";
                    shouldEndSession = false;
                    // participents = to returned game value from new response
                    repromptSpeech = "Just say how many people are playing.";
                }
                
                if (version != null)
                {
                    //picoloRule = newPicoloRules.Rules();
                    outputSpeech += " and playing the " + version + "version. First rule: ";// + picoloRule;
                    //cardText += picoloRule;
                }
                else if (version == null)
                {
                    outputSpeech += "Now, what version of the game do you wanna play";
                    shouldEndSession = false;
                    // participents = to returned game value from new response
                    repromptSpeech = "If you're stuck, just ask what versions of the game I can play";
                }
            }

            /// Voice Testing
            /// Failed
            if (Help_requested) {
                Help_requested = false; // Close off the method gettting called again 
                if (gameSelected == null)
                {
                    outputSpeech += "The Games availble are, Truth or Dare, Never Have I Ever, or Picolo";
                    repromptSpeech += "If you need further help, you can ask about each game individualy";
                }
                /*
                else if (participents == null)
                {
                    outputSpeech += "I need to know who's playing.Please say each name slowly and clearly";
                    repromptSpeech += "This isn't that hard. Please let me know who's playing";
                }
                else if (version == null)
                {
                    outputSpeech += "The versions availible to you are, Getting Started, Getting Silly, War, Caliente"; // TODO Pull this from a corresponding list of versions 
                    repromptSpeech += "Still not sure. I'd sugested Caliente"; //TODO select a random game
                }
                */
                else {
                    outputSpeech = "Help Intent";
                    repromptSpeech = "Help Intent";
                }
            }

            if (Totally_Lost) {
                Totally_Lost = false; // Close off the method gettting called again 
                if (gameSelected != null)
                {
                    
                    switch (gameSelected)
                    {
                        case "truth or are":
                            outputSpeech += "You want more help with Truth or dare ?";
                            break;
                        case "never have I ever":
                            outputSpeech += "You want more help with Never Have I Ever ?";
                            break;
                        case "picolo":
                            outputSpeech += "You want more help with Picolo ?";
                            break;
                    }
                }
                
                else if (participents != null)
                {
                    outputSpeech += "You want more help with the participents ?";
                }
                /*
                else if (version == null)
                {

                }
                */
                else
                {
                    outputSpeech += "Let's just take a second a figure out what you want to do.";
                }
            }
            /*
            /// Voice Testing
            /// Failed
            /// 
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
            */
            /// Voice Testing
            /// Failed
            /// 
            if (Confirm_requested) {
                // Here all the yes/no checked will be resolved
                if (Help_requested)
                {

                }
                if (Stop_requested) {
                    if (Leave_requested) {
                        outputSpeech += "Okay then. Goodbye, thank you.";
                        shouldEndSession = true; //Leave the skill
                    }
                }
            }
            /*
            /// Voice Testing
            /// Failed
            /// 
            if (Next_requested) {
                picoloRule = newPicoloRules.Rules();
                outputSpeech += "Next Rule is " + picoloRule;
                cardTitle += gameSelected + " : " + version;
                cardText += "The next rules is:\n" + picoloRule;
            }*/

            
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
            return skillResponse;
        } // End of Standard Skill Response

        private SkillResponse SSMLResponse(bool shouldEndSession, string ssmlOutputSpeech, string repromptSpeech, string cardTitle, string cardText, string gameSelected, string participents, string version)
        {
            var response = new ResponseBody
            {
                ShouldEndSession = shouldEndSession,
                OutputSpeech = new SsmlOutputSpeech {Ssml = ssmlOutputSpeech },
                Reprompt = new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = repromptSpeech } }
            };

            var skillResponse = new SkillResponse
            {
                Response = response,
                Version = "1.0"
            };
            return skillResponse;
        }

    } // End of Class

} // End of Namespace