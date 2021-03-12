
namespace FlappyBirdProject
{
	partial class ScoreWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreWindow));
			this.TitleHighScores = new System.Windows.Forms.Label();
			this.TextBoxNumbers = new System.Windows.Forms.TextBox();
			this.Rankings = new System.Windows.Forms.TextBox();
			this.YourScore = new System.Windows.Forms.TextBox();
			this.ReturnToMainMenu = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TitleHighScores
			// 
			this.TitleHighScores.AutoSize = true;
			this.TitleHighScores.BackColor = System.Drawing.Color.Transparent;
			this.TitleHighScores.Font = new System.Drawing.Font("Lucida Console", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleHighScores.Location = new System.Drawing.Point(6, 386);
			this.TitleHighScores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TitleHighScores.Name = "TitleHighScores";
			this.TitleHighScores.Size = new System.Drawing.Size(246, 35);
			this.TitleHighScores.TabIndex = 0;
			this.TitleHighScores.Text = "High Scores";
			this.TitleHighScores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TextBoxNumbers
			// 
			this.TextBoxNumbers.BackColor = System.Drawing.Color.White;
			this.TextBoxNumbers.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.TextBoxNumbers.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxNumbers.Location = new System.Drawing.Point(47, 45);
			this.TextBoxNumbers.Margin = new System.Windows.Forms.Padding(2);
			this.TextBoxNumbers.Multiline = true;
			this.TextBoxNumbers.Name = "TextBoxNumbers";
			this.TextBoxNumbers.ReadOnly = true;
			this.TextBoxNumbers.Size = new System.Drawing.Size(197, 259);
			this.TextBoxNumbers.TabIndex = 1;
			this.TextBoxNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Rankings
			// 
			this.Rankings.BackColor = System.Drawing.Color.White;
			this.Rankings.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Rankings.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Rankings.Location = new System.Drawing.Point(11, 45);
			this.Rankings.Multiline = true;
			this.Rankings.Name = "Rankings";
			this.Rankings.ReadOnly = true;
			this.Rankings.Size = new System.Drawing.Size(31, 259);
			this.Rankings.TabIndex = 2;
			this.Rankings.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8";
			this.Rankings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// YourScore
			// 
			this.YourScore.BackColor = System.Drawing.Color.White;
			this.YourScore.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.YourScore.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.YourScore.Location = new System.Drawing.Point(12, 310);
			this.YourScore.Multiline = true;
			this.YourScore.Name = "YourScore";
			this.YourScore.ReadOnly = true;
			this.YourScore.Size = new System.Drawing.Size(232, 29);
			this.YourScore.TabIndex = 3;
			this.YourScore.Text = "Your Score:";
			this.YourScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ReturnToMainMenu
			// 
			this.ReturnToMainMenu.BackColor = System.Drawing.Color.White;
			this.ReturnToMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ReturnToMainMenu.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReturnToMainMenu.Location = new System.Drawing.Point(11, 12);
			this.ReturnToMainMenu.Name = "ReturnToMainMenu";
			this.ReturnToMainMenu.Size = new System.Drawing.Size(233, 27);
			this.ReturnToMainMenu.TabIndex = 4;
			this.ReturnToMainMenu.Text = "RETURN TO MAIN MENU";
			this.ReturnToMainMenu.UseVisualStyleBackColor = false;
			this.ReturnToMainMenu.Click += new System.EventHandler(this.ReturnToMainMenu_Click);
			// 
			// ScoreWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightBlue;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(257, 431);
			this.Controls.Add(this.ReturnToMainMenu);
			this.Controls.Add(this.YourScore);
			this.Controls.Add(this.Rankings);
			this.Controls.Add(this.TextBoxNumbers);
			this.Controls.Add(this.TitleHighScores);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScoreWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "High Scores";
			this.Load += new System.EventHandler(this.ScoreWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TitleHighScores;
		private System.Windows.Forms.TextBox TextBoxNumbers;
		private System.Windows.Forms.TextBox Rankings;
		private System.Windows.Forms.TextBox YourScore;
		private System.Windows.Forms.Button ReturnToMainMenu;
	}
}