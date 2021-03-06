﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;

namespace Libraries2.Standard.Test.Assert
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void FalseExpression()
        {
            const string message = "fail because expression is false";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                ServiceContract.Require(() => false, message);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumServiceContractException fulcrumException)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }
    }
}
