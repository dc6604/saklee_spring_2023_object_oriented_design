using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Class for calories filter test data
    /// </summary>
    public class CaloriesFilterTestData: IEnumerable<object[]>
    {
        /// <summary>
        /// Calories test data
        /// </summary>
        private readonly List<object[]> _data = new()
        {
            new object[] {null, null, 19},
            new object[] {null, (uint?)950, 19},
            new object[] {null, (uint?)750, 17},
            new object[] {null, (uint?)100, 8},
            new object[] {(uint?)0, null, 19},
            new object[] {(uint?)200, null, 9},
            new object[] {(uint?)950, null, 0},
            new object[] {(uint?)0, (uint?)950, 19},
            new object[] {(uint?)200, (uint?)750, 7},
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
