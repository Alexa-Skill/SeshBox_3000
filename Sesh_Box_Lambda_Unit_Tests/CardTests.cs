using System;
using System.IO;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Newtonsoft.Json;
using Xunit;
using Alexa.NET.Response;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace Sesh_Box_Lambda.UnitTest
{
    public class CardTests{
        private const string ExamplesPath = @"Json";

        [Fact]
        public void Welcome_Response_Test() {

            var skillResponse = new SkillResponse
            {
                Version = "1.0",
                
                Response = new ResponseBody
                {
                    OutputSpeech = new PlainTextOutputSpeech
                    {
                        Text = "Welcome to Sesh Box 3000"
                    },
                    Card = new SimpleCard
                    {
                        Title = "Welcome",
                        Content = "Wellcome to Sesh Box 3000"
                    },
                    ShouldEndSession = false
                }
            };



            var json = JsonConvert.SerializeObject(skillResponse, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            const string example = "Welcome Response.json";
            var workingJson = File.ReadAllText(Path.Combine(ExamplesPath, example));

            workingJson = Regex.Replace(workingJson, @"\s", "");
            json = Regex.Replace(json, @"\s", "");

            Assert.Equal(workingJson, json);
        }



    }

}
