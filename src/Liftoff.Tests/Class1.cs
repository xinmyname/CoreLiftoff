using System;
using NUnit.Framework;
using Liftoff.Logging;
using MoqBotLite;
using Microsoft.Extensions.Logging;

namespace Liftoff.Tests {

    [TestFixture]
    public class Class1 {

        [Test]
        public void ItsAllGood() {

            using (var bot = new MoqBot()) {
                bot.Stub<IKeepTime>();
                bot.Stub<IManageFiles>();
                bot.Register(() => new RollingFileOptions{
                    LogFilePath = "/tmp/liftoff.tests.log",
                    MaximumAgeInDays = 30
                });
                var logger = bot.Get<RollingFileLogger>();

                logger.LogInformation("Hi everybody!");
            }
        }
    }
}
