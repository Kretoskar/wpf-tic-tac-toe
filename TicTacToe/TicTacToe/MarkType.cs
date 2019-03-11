using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe {
    /// <summary>
    /// The type of a value in a cell
    /// </summary>
    public enum MarkType {
        /// <summary>
        /// Cell hasn't been clicked yet
        /// </summary>
        Free,
        /// <summary>
        /// The cell is 0
        /// </summary>
        Nought,
        /// <summary>
        /// The cell is X
        /// </summary>
        Cross
    }
}
