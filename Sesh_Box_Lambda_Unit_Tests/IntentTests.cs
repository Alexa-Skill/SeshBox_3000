using System;
using System.IO;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Newtonsoft.Json;
using Xunit;

namespace Sesh_Box_Lambda.UnitTest
{

    public class IntentTests{
        private const string ExamplesPath = @"Examples";
        private const string WelcomeJson = "Start Game Version Request.json";
        private const string StartGameeJson = "Start Game Version Request Request.json";
        private const string StartGameVerioneJson = "Welcome Request.json";
        private const string NextCardJson = "Next Card.json";

        [Fact]
        public void Intent_Test() {

            var convertedObj = GetObjectFromExample<SkillRequest>(WelcomeJson);
            
            Assert.NotNull(convertedObj);
            var intent = ((IntentRequest)convertedObj.Request).Intent;
            Assert.Equal(typeof(IntentRequest), convertedObj.GetRequestType());

            convertedObj = GetObjectFromExample<SkillRequest>(StartGameeJson);
            intent = ((IntentRequest)convertedObj.Request).Intent;
            Assert.Equal("StartGameIntent", intent.Name);

            convertedObj = GetObjectFromExample<SkillRequest>(StartGameVerioneJson);
            intent = ((IntentRequest)convertedObj.Request).Intent;
            Assert.Equal("VersionIntent", intent.Name);

            convertedObj = GetObjectFromExample<SkillRequest>(NextCardJson);
            intent = ((IntentRequest)convertedObj.Request).Intent;
            Assert.Equal("VersionIntent", intent.Name);
        }

        private T GetObjectFromExample<T>(string filename)
        {
            var json = File.ReadAllText(Path.Combine(ExamplesPath, filename));
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}