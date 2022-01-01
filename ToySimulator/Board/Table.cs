using ToySimulator.Board;
using ToySimulator.Toy;

namespace ToySimulator.Board
{
    /// <summary>
    /// This class is the board that the toy sits on. It has a properties for rows and colums.
    /// There is also a method for checking if the position of the toy is valid.
    /// </summary>
    public class Table : ITable
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Table(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        // Le robot jouet ne doit pas tomber de la table pendant le mouvement. 
        // Cela inclut également le placement initial du robot jouet.
        public bool IsValidPosition(Position position)
        {
            return position.X < Columns && position.X >= 0 && 
                   position.Y < Rows && position.Y >= 0;
        }

        public void ValidateErrorPosition(Position position)
        {          
                
            if(position.X >= Columns)
            {
                position.X = 0;
            }else if(position.X < 0)
            {
                position.X = Columns - 1;
            }

            if (position.Y >= Rows)
            {
                position.Y = 0;
            }
            else if (position.Y < 0)
            {
                position.Y = Rows - 1;
            }
        }
    }
}
