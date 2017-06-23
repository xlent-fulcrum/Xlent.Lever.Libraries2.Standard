using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Libraries2.Standard.Test.Assert
{
    [TestClass]
    public class TestFulcrumAssert
    {
        [TestMethod]
        public void Fail()
        {
            const string message = "A random message";
            try
            {
                FulcrumAssert.Fail(message);
              UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumAssertionFailedException fulcrumException)
            {
               UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void IsTrueAssertionOk()
        {
            FulcrumAssert.IsTrue(true);
        }

        [TestMethod]
        public void IsTrueAssertionFail()
        {
            const string message = "A random message";
            try
            {
                FulcrumAssert.IsTrue(false, message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumAssertionFailedException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void IsNotNullAssertionOk()
        {
            FulcrumAssert.IsNotNull(new object());
        }

        [TestMethod]
        public void IsNotNullAssertionFail()
        {
            const string message = "A random message";
            try
            {
                FulcrumAssert.IsNotNull(null, message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumAssertionFailedException fulcrumException)
            {
                UT.Assert.IsNotNull(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void IsNotNullOrWhitespaceAssertionOk()
        {
            FulcrumAssert.IsNotNullOrWhiteSpace("NotEmpty");
        }

        [TestMethod]
        public void IsNotNullOrWhitespaceAssertionFail()
        {
            const string message = "A random message";
            try
            {
                FulcrumAssert.IsNotNullOrWhiteSpace("  ", message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumAssertionFailedException fulcrumException)
            {
                UT.Assert.IsNotNull(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void AreEqualAssertionOk()
        {
            FulcrumAssert.AreEqual(10, 5*2);
        }

        [TestMethod]
        public void AreEqualAssertionFail()
        {
            const string message = "A random message";
            try
            {
                FulcrumAssert.AreEqual("Knoll", "Tott");
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumAssertionFailedException fulcrumException)
            {
                UT.Assert.IsNotNull(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

    }
}
