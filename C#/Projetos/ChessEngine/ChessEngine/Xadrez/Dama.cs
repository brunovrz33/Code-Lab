using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            // left
            pos.setValues(position.row, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row, pos.column - 1);
            }

            // right
            pos.setValues(position.row, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row, pos.column + 1);
            }

            // above
            pos.setValues(position.row - 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row - 1, pos.column);
            }

            // below
            pos.setValues(position.row + 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row + 1, pos.column);
            }

            // NW
            pos.setValues(position.row - 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.setValues(position.row - 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row - 1, pos.column + 1);
            }

            // SE
            pos.setValues(position.row + 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row + 1, pos.column + 1);
            }

            // SW
            pos.setValues(position.row + 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.setValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}