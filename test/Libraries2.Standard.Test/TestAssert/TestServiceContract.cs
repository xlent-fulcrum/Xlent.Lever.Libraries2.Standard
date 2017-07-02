using System;
using Libraries2.Standard.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Libraries2.Standard.Test.TestAssert
{
    [TestClass]
    public class TestServiceContract
    {
        [TestMethod]
        public void NullObject()
        {
            const string parameterName = "parameterName";
            try
            {
                object nullObject = null;
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.RequireNotNull(nullObject, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void NullString()
        {
            const string parameterName = "parameterName";
            try
            {
                string nullString = null;
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.RequireNotNullOrWhitespace(nullString, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void EmptyString()
        {
            const string parameterName = "parameterName";
            try
            {
                string emptyString = "";
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.RequireNotNullOrWhitespace(emptyString, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void WhitespaceString()
        {
            const string parameterName = "parameterName";
            try
            {
                string whitespaceString = "     \t";
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.RequireNotNullOrWhitespace(whitespaceString, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void Fail()
        {
            const string message = "fail with this string";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.Fail(message);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void False()
        {
            const string message = "fail because false";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.Require(false, message);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void FalseParameterExpression()
        {
            const string parameterName = "parameterName";
            try
            {
                const int value = 23;
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.Require(value, x => x != 23, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void FalseParameter()
        {
            const string parameterName = "parameterName";
            try
            {
                const int value = 0;
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.RequireNotDefaultValue(value, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void IsValidatedOk()
        {
            var validatable = new Validatable
            {
                Name = "Jim"
            };
            ServiceContract.RequireValidated(validatable, nameof(validatable));
        }

        [TestMethod]
        public void IsValidatedFail()
        {
            try
            {
                var validatable = new Validatable();
                ServiceContract.RequireValidated(validatable, nameof(validatable));
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsNotNull(fulcrumException?.TechnicalMessage);
                Assert.IsTrue(fulcrumException.TechnicalMessage.StartsWith("Validation failed"));
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains("Property Name"));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        #region Less Than Greater Than

        [TestMethod]
        public void LessThanFail()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireLessThan(1, 1, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void LessThanOk()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireLessThan(10, 1, parameterName);
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected no exception but got {e.Message}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualFail()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireLessThanOrEqualTo(1, 2, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void LessThanOrEqualOk()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireLessThanOrEqualTo(1, 1, parameterName);
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected no exception but got {e.Message}.");
            }
        }

        [TestMethod]
        public void GreaterThanFail()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireGreaterThan(1, 1, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void GreaterThanOk()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireGreaterThan(1, 2, parameterName);
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected no exception but got {e.Message}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualFail()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireGreaterThanOrEqualTo(1, 2, parameterName);
                Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void GreaterThanOrEqualOk()
        {
            const string parameterName = "parameterName";
            try
            {
                ServiceContract.RequireGreaterThanOrEqualTo(1, 1, parameterName);
            }
            catch (Exception e)
            {
                Assert.Fail($"Expected no exception but got {e.Message}.");
            }
        }

        #endregion
    }
}
