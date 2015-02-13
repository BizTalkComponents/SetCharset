using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;

namespace BizTalkComponents.PipelineComponents.SetCharset.Tests.UnitTests
{
    [TestClass]
    public class SetCharsetTests
    {
        [TestMethod]
        public void TestChangeEncoding()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();

            var setCharset = new SetCharset
            {
                TargetCharset = "iso-8859-1"
            };

            var message = MessageHelper.CreateFromString("<test></test>");

            pipeline.AddComponent(setCharset, PipelineStage.Decode);
            var result = pipeline.Execute(message);

            Assert.AreEqual(1,result.Count);

            Assert.AreEqual("iso-8859-1", result[0].BodyPart.Charset);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestChangeInvalidEncoding()
        {
            var pipeline = PipelineFactory.CreateEmptyReceivePipeline();

            var setCharset = new SetCharset
            {
                TargetCharset = "invalid"
            };

            var message = MessageHelper.CreateFromString("<test></test>");

            pipeline.AddComponent(setCharset, PipelineStage.Decode);
            var result = pipeline.Execute(message);
        }
    }
}
