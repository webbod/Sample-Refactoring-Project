using System;
using Xunit;

namespace PinnacleSample.Tests.Helpers
{
    public static class CustomAssert
    {
        public static void Equal<T>(T expected, T actual, string message)
        {
            try
            {
                Assert.Equal(expected, actual);
            }
            catch(Exception ex)
            {
                throw new EqualException(expected, actual, message);
            }
        }
    }

    public class EqualException : Xunit.Sdk.EqualException
    {
        public EqualException(object expected, object actual, string userMessage)
               : base(expected, actual)
        {
            UserMessage = userMessage;
        }

        public override string Message => UserMessage + "\n" + base.Message;
    }
}
