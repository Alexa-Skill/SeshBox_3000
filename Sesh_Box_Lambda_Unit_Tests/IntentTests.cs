using System;
using System.IO;
using System.Linq;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Sesh_Box_Lambda.UnitTest {

    public class IntentTests{
        private const string ExamplesPath = @"Examples";
        private const string WelcomeJson = "Start Game Version Request.json";
        private const string StartGameeJson = "Start Game Version Request Request.json";
        private const string StartGameVerioneJson = "Welcome Request.json";
        private const string NextCardJson = "Next Card.json";

        public IntentTests()
        {
            // Do "global" initialization here; Only called once.
        }

        public void Dispose()
        {
            // Do "global" teardown here; Only called once.
        }


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

    public class DummyTests : IClassFixture<IntentTests>
    {
        public void SetFixture(IntentTests data)
        {
        }
    }
}