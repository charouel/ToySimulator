using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToySimulator.Toy;

namespace ToySimulator.Board
{
    public interface ITable
    {
        /// <summary>
        /// Valid the position
        /// </summary>
        /// <param name="position">position x,y</param>
        /// <returns>boot</returns>
        bool IsValidPosition(Position position);

        /// <summary>
        /// validate a position that exceeds the limits
        /// </summary>
        /// <param name="position">position x,y</param>
        void ValidateErrorPosition(Position position);
    }
}
