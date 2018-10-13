using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Runtime.InteropServices;

namespace EPAM.Core.ReportHelper.Tests
{

    [TestClass]
    public class ReportNameHelperTests
    {
        [TestMethod]
        [DynamicData("NormalizeFileNameTestData", DynamicDataSourceType.Property)]

        //[DataRow("Hello: my world", '_', "Hello_ my world")]
        //[DataRow("Hello my %world", '_', "Hello my %world")]
        //[DataRow("Hello my /world", '_', "Hello my _world")]
        public void NormalizeFileNameTest(string name, char repl, string expected)
        {
            var result = ReportNameHelper.NormalizeFileName(name, repl);

            result.Should().BeEquivalentTo(expected);
        }


        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            //Thread.Sleep(30 * 1000);
        }

        static object[][] NormalizeFileNameTestData
        {
            get
            {
                object[][] data = new object[][]
                {
            new object[]{"Hello: my world", '_', "Hello_ my world"},
            new object[]{"Hello my %world", '_', "Hello my %world"},
            new object[]{"Hello my /world", '_', "Hello my _world"}
                };

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    data[0][2] = "Hello: my world";
                    data[1][2] = "Hello my %world";
                    data[2][2] = "Hello my _world";
                }
                return data;
            }
        }

    }
}