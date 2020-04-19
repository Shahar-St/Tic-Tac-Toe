using System;

namespace TicTacToe
{
    [Flags]
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn't been clicked yet
        /// </summary>
        Free,
        
        /// <summary>
        /// The cell is a 0
        /// </summary>
        Nought,
        
        /// <summary>
        /// The cell is an X
        /// </summary>
        Cross

    }
}