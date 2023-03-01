using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitExamples.Data.FromClass
{

    public record RecordForTestData(int Input, int ExpectedResult);


    public class TestDataClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
    {
        new object[] { new RecordForTestData(1, 2) },
        new object[] { new RecordForTestData(4,8) },
        new object[] { new RecordForTestData(7, 14) }
    };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


  




}
