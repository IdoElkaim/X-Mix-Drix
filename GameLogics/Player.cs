namespace GameLogics
{
    public class Player
    {
        #region Properties

        public string Name { get; set; }

        public int PlayerNumber { get; }

        public bool IsHuman { get; set; }

        public char Sign { get; }

        public int Score { get; set; }
        #endregion

        #region Methods
        public static bool operator ==(Player i_Player1, Player i_Player2)
        {
            return i_Player1.PlayerNumber == i_Player2.PlayerNumber;
        }

        public static bool operator !=(Player i_Player1, Player i_Player2)
        {
            return !(i_Player1 == i_Player2);
        }

        public Player(string i_Name, int i_PlayerNumber, bool i_IsHuman)
        {
            if(i_Name == string.Empty)
            {
                i_Name = "Player " + i_PlayerNumber.ToString();
            }

            Name = i_Name;
            const char k_X = 'X', k_O = 'O';
            PlayerNumber = i_PlayerNumber;
            Score = 0;
            IsHuman = i_IsHuman;
            Sign = (PlayerNumber == 1) ? k_X : k_O;
        }

        public override bool Equals(object obj)
        {
            bool retVal = false;
            
            Player compareTo = obj as Player;
            if(compareTo != null)
            {
                retVal = PlayerNumber.Equals(compareTo.PlayerNumber);
            }

            return retVal;
        }

        #endregion
    }
}