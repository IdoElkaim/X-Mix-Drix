namespace GameUserInterface
{
    public partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.tbPlayerName2 = new System.Windows.Forms.TextBox();
            this.tbPlayerName1 = new System.Windows.Forms.TextBox();
            this.cbPlayer2 = new System.Windows.Forms.CheckBox();
            this.lblBoardSize = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(21, 21);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(84, 23);
            this.lblPlayers.TabIndex = 0;
            this.lblPlayers.Text = "Players:";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(42, 62);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(93, 23);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "Player 1:";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbPlayerName2
            // 
            this.tbPlayerName2.Enabled = false;
            this.tbPlayerName2.Location = new System.Drawing.Point(179, 103);
            this.tbPlayerName2.Name = "tbPlayerName2";
            this.tbPlayerName2.Size = new System.Drawing.Size(160, 32);
            this.tbPlayerName2.TabIndex = 3;
            this.tbPlayerName2.Text = "[Computer]";
            // 
            // tbPlayerName1
            // 
            this.tbPlayerName1.Location = new System.Drawing.Point(179, 57);
            this.tbPlayerName1.Name = "tbPlayerName1";
            this.tbPlayerName1.Size = new System.Drawing.Size(160, 32);
            this.tbPlayerName1.TabIndex = 1;
            // 
            // cbPlayer2
            // 
            this.cbPlayer2.AutoSize = true;
            this.cbPlayer2.Location = new System.Drawing.Point(46, 105);
            this.cbPlayer2.Name = "cbPlayer2";
            this.cbPlayer2.Size = new System.Drawing.Size(115, 27);
            this.cbPlayer2.TabIndex = 2;
            this.cbPlayer2.Text = "Player 2:";
            this.cbPlayer2.UseVisualStyleBackColor = true;
            this.cbPlayer2.CheckedChanged += new System.EventHandler(this.cbPlayer2_CheckedChanged);
            // 
            // lblBoardSize
            // 
            this.lblBoardSize.AutoSize = true;
            this.lblBoardSize.Location = new System.Drawing.Point(21, 156);
            this.lblBoardSize.Name = "lblBoardSize";
            this.lblBoardSize.Size = new System.Drawing.Size(114, 23);
            this.lblBoardSize.TabIndex = 0;
            this.lblBoardSize.Text = "Board Size:";
            this.lblBoardSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(52, 206);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(66, 23);
            this.lblRows.TabIndex = 0;
            this.lblRows.Text = "Rows:";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(196, 206);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(57, 23);
            this.lblCols.TabIndex = 0;
            this.lblCols.Text = "Cols:";
            this.lblCols.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(135, 204);
            this.nUDRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(47, 32);
            this.nUDRows.TabIndex = 4;
            this.nUDRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDRows.ValueChanged += new System.EventHandler(this.nUDRows_ValueChanged);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(270, 204);
            this.nUDCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(48, 32);
            this.nUDCols.TabIndex = 5;
            this.nUDCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCols.ValueChanged += new System.EventHandler(this.nUDCols_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(32, 281);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(307, 34);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 333);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.cbPlayer2);
            this.Controls.Add(this.tbPlayerName1);
            this.Controls.Add(this.tbPlayerName2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.lblBoardSize);
            this.Controls.Add(this.lblPlayers);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.TextBox tbPlayerName2;
        private System.Windows.Forms.TextBox tbPlayerName1;
        private System.Windows.Forms.CheckBox cbPlayer2;
        private System.Windows.Forms.Label lblBoardSize;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.NumericUpDown nUDCols;
        private System.Windows.Forms.Button btnStart;
    }
}