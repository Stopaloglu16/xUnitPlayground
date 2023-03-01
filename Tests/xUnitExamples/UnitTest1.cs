using xUnitExamples.Data.FromClass;

namespace xUnitExamples
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleTest_DataAssign_TruePass()
        {
            //arrange
            var fieldVal1 = 1;
            var fieldVal2 = 2;

            //act
            var sum0 = fieldVal1 + fieldVal2;

            //assert
            Assert.True(3 == sum0, "Result is not correct");
        }


        [Fact]
        public void SimpleTest_DataAssign_EqualPass()
        {
            //arrange
            var fieldVal1 = 1;
            var fieldVal2 = 2;

            //act
            var sum0 = fieldVal1 + fieldVal2;

            //assert
            Assert.Equal(3, sum0);
        }


        /// <summary>
        /// The theory attribute to pass simple parameters to the test case.
        /// </summary>
        [Theory]
        [InlineData(2, 3, 5)]
        public void SimpleTest_InlineData_EqualPass(int fieldVal1, int fieldVal2, int expect)
        {
            //act
            var sum0 = fieldVal1 + fieldVal2;

            //assert
            Assert.Equal(expect, sum0);
        }

        /// <summary>
        /// If the test case takes the type as a parameter
        /// Also, One of the advantage is clean code and reusability.
        /// </summary>
        [Theory]
        [ClassData(typeof(TestDataClass))]
        public void DoubleUp_ClassData_EqualPass(RecordForTestData data)
        {
            Assert.Equal(data.Input, data.ExpectedResult / 2);
        }


        /// <summary>
        /// For loading the complex data for the test cases. Any static property or method can be assigned to the XUnit memberdata attribute
        /// The [MemberData] attribute can be used to fetch data for a [Theory] from a static property or method of a type
        /// </summary>
        [Theory]
        [MemberData(nameof(TestDataWithObjects))]
        public void DoubleUp_MemberData_EqualPass(RecordForTestData data)
        {
            Assert.Equal(data.Input, data.ExpectedResult / 2);

        }

        public static IEnumerable<object[]> TestDataWithObjects => new[]
        {
           new object[] { new RecordForTestData(1, 2) },
           new object[] { new RecordForTestData(4,8) },
           new object[] { new RecordForTestData(7, 14) }
        };


    }
}