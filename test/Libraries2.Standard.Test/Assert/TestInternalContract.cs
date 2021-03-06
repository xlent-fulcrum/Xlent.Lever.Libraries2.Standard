﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Libraries2.Standard.Test.Assert
{
    [TestClass]
    public class TestInternalContract
    {
        [TestMethod]
        public void NullObject()
        {
            const string parameterName = "parameterName";
            try
            {
                object nullObject = null;
                // ReSharper disable once ExpressionIsAlwaysNull
                InternalContract.RequireNotNull(nullObject, parameterName);
              UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
               UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                InternalContract.RequireNotNullOrWhitespace(nullString, parameterName);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                InternalContract.RequireNotNullOrWhitespace(emptyString, parameterName);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                InternalContract.RequireNotNullOrWhitespace(whitespaceString, parameterName);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void Fail()
        {
            const string message = "fail with this string";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                InternalContract.Fail(message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void False()
        {
            const string message = "fail because false";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                InternalContract.Require(false, message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }

        [TestMethod]
        public void FalseExpression()
        {
            const string message = "fail because expression is false";
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                InternalContract.Require((() => false), message);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(message));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                InternalContract.Require(value, x => x != 23, parameterName);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
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
                InternalContract.RequireNotDefaultValue(value, parameterName);
                UT.Assert.Fail("An exception should have been thrown");
            }
            catch (FulcrumContractException fulcrumException)
            {
                UT.Assert.IsTrue(fulcrumException.TechnicalMessage.Contains(parameterName));
            }
            catch (Exception e)
            {
                UT.Assert.Fail($"Expected a specific FulcrumException but got {e.GetType().FullName}.");
            }
        }
    }
}
