using System;
using System.Drawing;
using System.Threading;

namespace GameLogics
{
    public class Game
    {
        public event Action<int, int, char> HasChanged;

        public event Action Draw;
        
        public event Action<Player> PlayerWon;

        #region Properties
        private readonly char[,] r_GameBoard;
        
        private readonly Random r_Rnd = new Random();
        
        private int m_TurnCount;
        
        private Player m_CurrentPlayer;
        
        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }
        
        private readonly int r_Size;
        
        public Player FirstPlayer { get; }
        
        public Player SecondPlayer { get; }
        #endregion

        #region Methods
        public Game(int i_Size, bool i_IsPlayer2Human, string i_PlayerName1, string i_PlayerName2)
        {
            const bool v_NotARobot = true;
            int playerNumber = 1;
            r_GameBoard = new char[i_Size, i_Size];
            r_Size = i_Size;
            m_TurnCount = 0;
            
            FirstPlayer = new Player(i_PlayerName1, playerNumber++, v_NotARobot);
            SecondPlayer = new Player(i_PlayerName2, playerNumber, i_IsPlayer2Human);
            m_CurrentPlayer = FirstPlayer;

            clearBoard();
        }

        private void changePlayer(Player i_CurrentPlayer)
        {
            m_CurrentPlayer = i_CurrentPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;
        }

        public void PlayATurn(Point? i_Point)
        {
            r_GameBoard.SetValue(m_CurrentPlayer.Sign, i_Point.Value.X - 1, i_Point.Value.Y - 1);
            OnHasChanged(i_Point.Value.X, i_Point.Value.Y, m_CurrentPlayer.Sign);
            if(isGameOver(m_CurrentPlayer.Sign)) // returns true if someone won the game
            {
                return;
            }

            turnPromote();
            if(checkForDraw())
            {
                return;
            }

            if(!CurrentPlayer.IsHuman)
            {
                machineMove();
            }
        }

        private void machineMove()
        {
            const int k_One = 1;
            int x = r_Rnd.Next(k_One, r_Size + 1);
            int y = r_Rnd.Next(k_One, r_Size + 1);
            Point toPlay = new Point(x, y);
            bool v_IsAvailablePoint = isPointAvailable(toPlay);

            while (!v_IsAvailablePoint)
            {
                toPlay.X = r_Rnd.Next(k_One, r_Size + 1);
                toPlay.Y = r_Rnd.Next(k_One, r_Size + 1);
                v_IsAvailablePoint = isPointAvailable(toPlay);
            }

            Thread.Sleep(500);
            PlayATurn(toPlay);
        }

        private bool isPointAvailable(Point i_ToPlay)
        {
            return getCharFromMatrix(i_ToPlay.X, i_ToPlay.Y) == ' ';
        }

        private bool isGameOver(char i_PlayerSign)
        {
            bool result = isThereRow(i_PlayerSign) 
                          || isThereCol(i_PlayerSign) 
                          || isThereDiag(i_PlayerSign) 
                          || isThereReverseDiag(i_PlayerSign);
            if(result)
            {
                changePlayer(m_CurrentPlayer);
                OnPlayerWon(m_CurrentPlayer);
            }

            return result;
        }

        private bool isThereRow(char i_PlayerSign)
        {
            bool result = false;
            int length = r_Size;

            for (int i = 0; i < length; i++)
            {
                if (result)
                {
                    break;
                }

                for (int j = 0; j < length; j++)
                {
                    if ((char)r_GameBoard.GetValue(i, j) != i_PlayerSign)
                    {
                        break;
                    }

                    if (j == length - 1)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool isThereCol(char i_PlayerSign)
        {
            bool result = false;
            int length = r_Size;

            for (int i = 0; i < length; i++)
            {
                if (result)
                {
                    break;
                }

                for (int j = 0; j < length; j++)
                {
                    if ((char)r_GameBoard.GetValue(j, i) != i_PlayerSign)
                    {
                        break;
                    }

                    if (j == length - 1)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool isThereDiag(char i_PlayerSign)
        {
            bool result = false;
            int length = r_Size;
            for (int i = 0; i < length; i++)
            {
                if ((char)r_GameBoard.GetValue(i, i) != i_PlayerSign)
                {
                    break;
                }

                if (i == length - 1)
                {
                    result = true;
                }
            }

            return result;
        }

        private bool isThereReverseDiag(char i_PlayerSign)
        {
            bool result = false;
            int length = r_Size;

            for (int i = 0; i < length; i++)
            {
                if ((char)r_GameBoard.GetValue(i, length - 1 - i) != i_PlayerSign)
                {
                    break;
                }

                if (i == length - 1)
                {
                    result = true;
                }
            }

            return result;
        }

        private char getCharFromMatrix(int i_X, int i_Y)
        {
            return r_GameBoard[i_X - 1, i_Y - 1];
        }

        private void clearBoard()
        {
            for(int i = 0; i < r_Size; i++)
            {
                for(int j = 0; j < r_Size; j++)
                {
                    r_GameBoard[i, j] = ' ';
                    OnHasChanged(i + 1, j + 1, ' ');
                }
            }
        }

        public void RestartGame()
        {
            clearBoard();
            m_TurnCount = 0;
            m_CurrentPlayer = FirstPlayer;
        }

        private void turnPromote()
        {
            m_TurnCount++;
            changePlayer(m_CurrentPlayer);
        }

        private bool checkForDraw()
        {
            bool isDraw = false;
            if(m_TurnCount == r_Size * r_Size)
            {
                isDraw = true;
                OnDraw();
            }

            return isDraw;
        }

        protected virtual void OnPlayerWon(Player i_Winner)
        {
            PlayerWon?.Invoke(i_Winner);
        }

        protected virtual void OnDraw()
        {
            Draw?.Invoke();
        }

        protected virtual void OnHasChanged(int i_I, int i_J, char i_Sign)
        {
            HasChanged?.Invoke(i_I, i_J, i_Sign);
        }
        #endregion
    }
}
