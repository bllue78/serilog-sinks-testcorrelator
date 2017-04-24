﻿using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Xunit;

namespace Serilog.Utilities.ConcurrentCorrelator.Tests
{
    public partial class TestSerilogLogEventsTests
    {
        [Fact]
        [Test]
        [TestMethod]
        public void GetLogEventsWithContextIdentifier_returns_empty_if_no_LogEvents_have_been_logged()
        {
            using (var context = TestSerilogLogEvents.EstablishTestLogContext())
            {
                TestSerilogLogEvents.GetLogEventsWithContextIdentifier(context.Identifier).Should().BeEmpty();
            }
        }

        [Fact]
        [Test]
        [TestMethod]
        public void
            GetLogEventsWithContextIdentifier_returns_empty_if_no_LogEvents_have_been_logged_with_the_context_identifier()
        {
            Log.Information("");

            using (var context = TestSerilogLogEvents.EstablishTestLogContext())
            {
                TestSerilogLogEvents.GetLogEventsWithContextIdentifier(context.Identifier).Should().BeEmpty();
            }
        }

        [Fact]
        [Test]
        [TestMethod]
        public void
            GetLogEventsWithContextIdentifier_returns_all_LogEvents_that_have_been_logged_with_the_context_identifier()
        {
            using (var context = TestSerilogLogEvents.EstablishTestLogContext())
            {
                const int expectedCount = 4;

                foreach (var unused in Enumerable.Range(0, expectedCount))
                {
                    Log.Information("");
                }

                TestSerilogLogEvents.GetLogEventsWithContextIdentifier(context.Identifier).Should().HaveCount(expectedCount);
            }
        }
    }
}