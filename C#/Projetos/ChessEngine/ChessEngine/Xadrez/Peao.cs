using board;

namespace chess
{

    class Pawn : Piece
    {

        private ChessGame game;

        public Pawn(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool isFree(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.setValues(position.row - 1, position.column);
                if (board.isValidPosition(pos) && isFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (board.isValidPosition(p2) && isFree(p2) && board.isValidPosition(pos) && isFree(pos) && moveCount == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row - 1, position.column - 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row - 1, position.column + 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // #specialmove en passant
                if (position.row == 3)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.isValidPosition(left) && hasEnemy(left) && board.piece(left) == game.enPassantVulnerable)
                    {
                        mat[left.row - 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.isValidPosition(right) && hasEnemy(right) && board.piece(right) == game.enPassantVulnerable)
                    {
                        mat[right.row - 1, right.column] = true;
                    }
                }
            }
            else
            {
                pos.setValues(position.row + 1, position.column);
                if (board.isValidPosition(pos) && isFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (board.isValidPosition(p2) && isFree(p2) && board.isValidPosition(pos) && isFree(pos) && moveCount == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row + 1, position.column - 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.setValues(position.row + 1, position.column + 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // #specialmove en passant
                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.isValidPosition(left) && hasEnemy(left) && board.piece(left) == game.enPassantVulnerable)
                    {
                        mat[left.row + 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.isValidPosition(right) && hasEnemy(right) && board.piece(right) == game.enPassantVulnerable)
                    {
                        mat[right.row + 1, right.column] = true;
                    }
                }
            }

            return mat;
        }
    }
}