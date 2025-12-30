using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Class for price filter test data
    /// </summary>
    public class PriceFilterTestData: IEnumerable<object[]>
    {
        /// <summary>
        /// Price test data
        /// </summary>
        private readonly List<object[]> _data = new()
        {
            new object[] {null, null, 19},
            new object[] {null, 8.00m, 18},
            new object[] {null, 8.50m, 19},
            new object[] {null, 1.50m, 7},
            new object[] {1.50m, null, 14},
            new object[] {1.00m, null, 16},
            new object[] {2.50m, 6.50m, 1},
            new object[] {2.00m, 6.50m, 9},
            new object[] {9.00m, 10.00m, 0}
        };

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns>GetEnumerator</returns>
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns>GetEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
