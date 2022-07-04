using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GameLogics;


namespace GameUserInterface
{
    public partial class FormGame : Form
    {
        public class RowColButton : Button
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public RowColButton(int i_Row, int i_Col)
            {
                Row = i_Row;
                Col = i_Col;
                this.Size = new Size(60, 60);
                this.BackColor = Color.FromArgb(3, 89, 115);
                this.Location = new Point((65 * (Col - 1)) + 25, (65 * (Row - 1)) + 20);
                this.Text = string.Empty;
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Visible = true;
                this.Enabled = true;
            }
        }

        #region Properties
        private readonly Game r_Game;

        private readonly RowColButton[,] r_ButtonsBoard;
        // these are for being able to move the game window
        private int mouseX, mouseY;

        private bool mouseDown = false;
        #endregion

        #region Methods
        // first method is for the rounded edges of the game window
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public FormGame()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(
                    0, 0, Width, Height, 25, 25));
        }
        /// <summary>
        /// constructing the form with an array of custom buttons (RowColButtons),
        /// which will simulate the real board of the game, and subscribing delegates to relevant events
        /// </summary>
        public FormGame(int i_BoardSize, bool i_IsPlayer2Human, string i_Player1Name, string i_Player2Name)
        {
            r_Game = new Game(i_BoardSize, i_IsPlayer2Human, i_Player1Name, i_Player2Name);
            r_ButtonsBoard = new RowColButton[i_BoardSize, i_BoardSize];
            
            // Events
            r_Game.HasChanged += this.game_HasChanged;
            r_Game.Draw += this.game_Draw;
            r_Game.PlayerWon += this.game_PlayerWon;

            // Creating form's components
            createButtons(r_ButtonsBoard, i_BoardSize);
            InitializeComponent();
            updateLayout(i_BoardSize, i_Player1Name, i_Player2Name, i_IsPlayer2Human);
            
            Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, Width, Height, 25, 25));
        }
        
        private void createButtons(RowColButton[,] i_Buttons, int i_BoardSize)
        {
            for(int i = 0; i < i_BoardSize; i++)
            {
                for(int j = 0; j < i_BoardSize; j++)
                {
                    r_ButtonsBoard[i, j] = new RowColButton(i + 1, j + 1);
                    r_ButtonsBoard[i, j].Click += buttons_Click;
                    this.Controls.Add(r_ButtonsBoard[i, j]);
                }
            }
        }

        private void updateLayout(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsPlayer2Human)
        {
            this.ClientSize = new Size((65 * i_BoardSize) + 45, (65 * i_BoardSize) + 75);
            this.btnQuit.Left = pnlDashboard.Width - btnQuit.Width - 45;

            if(i_Player1Name != string.Empty)
            {
                lblPlayer1.Text = i_Player1Name + ':';
            }
            
            if(!i_IsPlayer2Human)
            {
                lblPlayer2.Text = "Computer:";
            }
            else if(i_Player2Name != string.Empty)
            {
                lblPlayer2.Text = i_Player2Name + ':'; 
            }
        }
        /// <summary>
        /// will show the requested MessageBox depending on the parameter's value:
        /// 1 -> Win, 0 -> Draw
        /// </summary>
        private void showMessageBox(int i_WinOrDraw, Player? i_Winner)
        {
            const int k_Win = 1;
            StringBuilder message = new StringBuilder();
            message.Append(i_WinOrDraw == 1 ? $"The Winner is {i_Winner.Name}!" : $"Tie!");
            message.AppendLine();
            message.Append($"Would you like to play another round?");
            string caption = i_WinOrDraw == 1 ? "A Win!" : "A Tie!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message.ToString(), caption, buttons);

            if(result == DialogResult.Yes)
            {
                if(i_WinOrDraw == k_Win)
                {
                    i_Winner.Score++;
                }

                lblPlayer1Score.Text = r_Game.FirstPlayer.Score.ToString();
                lblPlayer2Score.Text = r_Game.SecondPlayer.Score.ToString();
                r_Game.RestartGame();
            }
            else
            {
                quit();
            }
        }

        private void quit()
        {
            this.Close();
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// makes contact with the game board and makes a move according to which button was press,
        /// and to which player is making the move
        /// </summary>
        private void buttons_Click(object sender, EventArgs e)
        {
            RowColButton btnPressed = (RowColButton)sender;
            r_Game.PlayATurn(new Point(btnPressed.Row, btnPressed.Col));
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            quit();
        }

        private void FormGame_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void FormGame_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X;
            mouseY = MousePosition.Y;

            if(mouseDown)
            {
                this.Location = new Point(mouseX - 120, mouseY - 10);
            }
        }

        private void FormGame_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        /// <summary>
        /// whenever the board is changed (inside the r_Game variable),
        /// this method is called to update the relevant RowColButton from the array
        /// of buttons, to have the same text as it's matching place in the array
        /// </summary>
        private void game_HasChanged(int i_I, int i_J, char i_Sign)
        {
            r_ButtonsBoard[i_I - 1, i_J - 1].Text = i_Sign.ToString();
            r_ButtonsBoard[i_I - 1, i_J - 1].Font = new System.Drawing.Font(
                "Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            r_ButtonsBoard[i_I - 1, i_J - 1].Enabled = (i_Sign != 'X' && i_Sign != 'O');
        }

        private void game_Draw()
        {
            showMessageBox(0, null);
        }

        private void game_PlayerWon(Player i_Winner)
        {
            showMessageBox(1, i_Winner);
        }
        #endregion
    }
}
