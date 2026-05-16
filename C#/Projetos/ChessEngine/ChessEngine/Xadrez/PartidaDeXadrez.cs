using board;

namespace chess
{
    class ChessGame
    {

        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }
        public Piece enPassantVulnerable { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            enPassantVulnerable = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece makeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoveCount();
            Piece capturedPiece = board.removePiece(destination);
            board.placePiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            // #specialmove kingside castling
            if (p is King && destination.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.row, origin.column + 3);
                Position rookDestination = new Position(origin.row, origin.column + 1);
                Piece rook = board.removePiece(rookOrigin);
                rook.incrementMoveCount();
                board.placePiece(rook, rookDestination);
            }

            // #specialmove queenside castling
            if (p is King && destination.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.row, origin.column - 4);
                Position rookDestination = new Position(origin.row, origin.column - 1);
                Piece rook = board.removePiece(rookOrigin);
                rook.incrementMoveCount();
                board.placePiece(rook, rookDestination);
            }

            // #specialmove en passant
            if (p is Pawn)
            {
                if (origin.column != destination.column && capturedPiece == null)
                {
                    Position pawnPos;
                    if (p.color == Color.White)
                    {
                        pawnPos = new Position(destination.row + 1, destination.column);
                    }
                    else
                    {
                        pawnPos = new Position(destination.row - 1, destination.column);
                    }
                    capturedPiece = board.removePiece(pawnPos);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.removePiece(destination);
            p.decrementMoveCount();
            if (capturedPiece != null)
            {
                board.placePiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.placePiece(p, origin);

            // #specialmove kingside castling
            if (p is King && destination.column == origin.column + 2)
            {
                Position rookOrigin = new Position(origin.row, origin.column + 3);
                Position rookDestination = new Position(origin.row, origin.column + 1);
                Piece rook = board.removePiece(rookDestination);
                rook.decrementMoveCount();
                board.placePiece(rook, rookOrigin);
            }

            // #specialmove queenside castling
            if (p is King && destination.column == origin.column - 2)
            {
                Position rookOrigin = new Position(origin.row, origin.column - 4);
                Position rookDestination = new Position(origin.row, origin.column - 1);
                Piece rook = board.removePiece(rookDestination);
                rook.decrementMoveCount();
                board.placePiece(rook, rookOrigin);
            }

            // #specialmove en passant
            if (p is Pawn)
            {
                if (origin.column != destination.column && capturedPiece == enPassantVulnerable)
                {
                    Piece pawn = board.removePiece(destination);
                    Position pawnPos;
                    if (p.color == Color.White)
                    {
                        pawnPos = new Position(3, destination.column);
                    }
                    else
                    {
                        pawnPos = new Position(4, destination.column);
                    }
                    board.placePiece(pawn, pawnPos);
                }
            }
        }

        public void performMove(Position origin, Position destination)
        {
            Piece capturedPiece = makeMove(origin, destination);

            if (isInCheck(currentPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            Piece p = board.piece(destination);

            // #specialmove promotion
            if (p is Pawn)
            {
                if ((p.color == Color.White && destination.row == 0) || (p.color == Color.Black && destination.row == 7))
                {
                    p = board.removePiece(destination);
                    pieces.Remove(p);
                    Piece queen = new Queen(board, p.color);
                    board.placePiece(queen, destination);
                    pieces.Add(queen);
                }
            }

            if (isInCheck(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (isCheckmate(opponent(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                switchPlayer();
            }

            // #specialmove en passant
            if (p is Pawn && (destination.row == origin.row - 2 || destination.row == origin.row + 2))
            {
                enPassantVulnerable = p;
            }
            else
            {
                enPassantVulnerable = null;
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no piece at the chosen origin position!");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The chosen piece does not belong to you!");
            }
            if (!board.piece(pos).hasPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen piece!");
            }
        }

        public void validateDestinationPosition(Position origin, Position destination)
        {
            if (!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void switchPlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInPlay(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece k = king(color);
            if (k == null)
            {
                throw new BoardException("There is no king of color " + color + " on the board!");
            }
            foreach (Piece x in piecesInPlay(opponent(color)))
            {
                bool[,] mat = x.possibleMoves();
                if (mat[k.position.row, k.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isCheckmate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach (Piece x in piecesInPlay(color))
            {
                bool[,] mat = x.possibleMoves();
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = makeMove(origin, destination);
                            bool inCheck = isInCheck(color);
                            undoMove(origin, destination, capturedPiece);
                            if (!inCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void placeNewPiece(char column, int row, Piece piece)
        {
            board.placePiece(piece, new ChessPosition(column, row).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('a', 1, new Rook(board, Color.White));
            placeNewPiece('b', 1, new Knight(board, Color.White));
            placeNewPiece('c', 1, new Bishop(board, Color.White));
            placeNewPiece('d', 1, new Queen(board, Color.White));
            placeNewPiece('e', 1, new King(board, Color.White, this));
            placeNewPiece('f', 1, new Bishop(board, Color.White));
            placeNewPiece('g', 1, new Knight(board, Color.White));
            placeNewPiece('h', 1, new Rook(board, Color.White));
            placeNewPiece('a', 2, new Pawn(board, Color.White, this));
            placeNewPiece('b', 2, new Pawn(board, Color.White, this));
            placeNewPiece('c', 2, new Pawn(board, Color.White, this));
            placeNewPiece('d', 2, new Pawn(board, Color.White, this));
            placeNewPiece('e', 2, new Pawn(board, Color.White, this));
            placeNewPiece('f', 2, new Pawn(board, Color.White, this));
            placeNewPiece('g', 2, new Pawn(board, Color.White, this));
            placeNewPiece('h', 2, new Pawn(board, Color.White, this));
            placeNewPiece('a', 8, new Rook(board, Color.Black));
            placeNewPiece('b', 8, new Knight(board, Color.Black));
            placeNewPiece('c', 8, new Bishop(board, Color.Black));
            placeNewPiece('d', 8, new Queen(board, Color.Black));
            placeNewPiece('e', 8, new King(board, Color.Black, this));
            placeNewPiece('f', 8, new Bishop(board, Color.Black));
            placeNewPiece('g', 8, new Knight(board, Color.Black));
            placeNewPiece('h', 8, new Rook(board, Color.Black));
            placeNewPiece('a', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('b', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('c', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('d', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('e', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('f', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('g', 7, new Pawn(board, Color.Black, this));
            placeNewPiece('h', 7, new Pawn(board, Color.Black, this));
        }
    }
}