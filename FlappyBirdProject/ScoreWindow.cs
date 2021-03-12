using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FlappyBirdProject
{
	public partial class ScoreWindow : Form
	{
		int score;
		string path = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\FlappyBirdProject\HighScores.txt";
		public ScoreWindow(int my_score)
		{
			InitializeComponent();
			ReturnToMainMenu.Select();
			score = my_score;
		}

		private void ScoreWindow_Load(object sender, EventArgs e)
		{
			YourScore.AppendText(" " + score.ToString());

			using (StreamReader sr = File.OpenText(path))
			{
				int count = 0;
				string s = "";
				while ((s = sr.ReadLine()) != null && count < 8)
				{
					TextBoxNumbers.AppendText(s);
					TextBoxNumbers.AppendText(Environment.NewLine);
					count++;
				}
			}

		}

		private void ReturnToMainMenu_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
