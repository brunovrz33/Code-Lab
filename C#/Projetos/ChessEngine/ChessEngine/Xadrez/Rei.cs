using board;

namespace chess
{
    class King : Piece
    {
        private ChessGame game;

        public King(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        private bool rookEligibleForCastling(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.moveCount == 0;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            // above
            pos.setValues(position.row - 1, position.column);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // NE
            pos.setValues(position.row - 1, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // right
            pos.setValues(position.row, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // SE
            pos.setValues(position.row + 1, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // below
            pos.setValues(position.row + 1, position.column);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // SW
            pos.setValues(position.row + 1, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // left
            pos.setValues(position.row, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            // NW
            pos.setValues(position.row - 1, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            // #specialmove castling
            if (moveCount == 0 && !game.check)
            {
                // #specialmove kingside castling
                Position rookPos1 = new Position(position.row, position.column + 3);
                if (rookEligibleForCastling(rookPos1))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.row, position.column + 2] = true;
                    }
                }
                // #specialmove queenside castling
                Position rookPos2 = new Position(position.row, position.column - 4);
                if (rookEligibleForCastling(rookPos2))
                {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}