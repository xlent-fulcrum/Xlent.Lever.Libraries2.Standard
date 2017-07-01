using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Decoupling.Model;

namespace Libraries2.Standard.Test.TestDecoupling
{
    [TestClass]
    public class TestConceptValue
    {
        [TestMethod]
        public void ParseContext()
        {
            var conceptValue = ConceptValue.Parse("(concept!context!value)");
            Assert.AreEqual("concept", conceptValue.ConceptName);
            Assert.AreEqual("context", conceptValue.ContextName);
            Assert.AreEqual("value", conceptValue.Value);
            Assert.IsNull(conceptValue.ClientName);
        }

        [TestMethod]
        public void ParseClient()
        {
            var conceptValue = ConceptValue.Parse("(concept!~client!value)");
            Assert.AreEqual("concept", conceptValue.ConceptName);
            Assert.AreEqual("client", conceptValue.ClientName);
            Assert.AreEqual("value", conceptValue.Value);
            Assert.IsNull(conceptValue.ContextName);
        }

        [TestMethod]
        public void ContextToPath()
        {
            var conceptValue = new ConceptValue
            {
                ConceptName = "concept",
                ContextName = "context",
                Value = "value"
            };
            var path = conceptValue.ToPath();
            Assert.AreEqual("(concept!context!value)", path);
        }

        [TestMethod]
        public void ClientToPath()
        {
            var conceptValue = new ConceptValue
            {
                ConceptName = "concept",
                ClientName = "client",
                Value = "value"
            };
            var path = conceptValue.ToPath();
            Assert.AreEqual("(concept!~client!value)", path);
        }
    }
}
