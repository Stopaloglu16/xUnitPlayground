namespace xUnitExamples
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnSum()
        {
            //arrange
            var fieldVal1 = 1;
            var fieldVal2 = 2;

            //act
            var sum0 = fieldVal1 + fieldVal2;

            //assert
            Assert.Equal(3, sum0);


        }
    }
}