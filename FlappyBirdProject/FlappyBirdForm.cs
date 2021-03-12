using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace FlappyBirdProject
{
	public partial class FlappyBirdForm : Form

	{
		private int gravity = 3; // how fast it falls
		private int jumpSpeed = -4; // how high it jumps
		private int miliseconds = 0; // to know when to stop the jump timer

		private int pipeSpeed = -12;

		private int Score = 0;

		private int deltaHeight = 0;

		private Image frame1;
		private Image frame2;
		private Image frame3;

		private bool dead = false;

		private string path_coin_sound = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\coin.wav";
		private string path_die_sound = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\hit.wav";
		private string path_jump_sound = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\wing.wav";


		private PictureBox pipeTop;
		private PictureBox coin;
		private PictureBox pipeBot;
		private bool gotCoin = false;

		private BackgroundWorker PipeTimer = new BackgroundWorker();

		private int X_pipes = 0;
		private bool pipesBehind = false;

		public FlappyBirdForm()
		{
			InitializeComponent();

			this.Select();

			frame1 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_0.png");
			frame2 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_1.png");
			frame3 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_2.png");
			GravityTimer.Start();

			PipeTimer.DoWork += new DoWorkEventHandler(PipeTimer_Work);
			SpawnPipes();
		}

		private bool CheckBirdCollisionWithPipes()
		{
			// We need the bottom Y Axis of the pipeTop
			// And the top Y Axis of the pipeBot

			Point p1 = pipeTop.Location;
			float Y1 = p1.Y + pipeTop.Size.Height;
			float X1_L = p1.X;
			float X1_R = p1.X + pipeTop.Size.Width;

			Point p2 = pipeBot.Location;
			float Y2 = p2.Y;

			// Calculating the top Y axis and the bot Y axis of the bird
			Point P = FlappyBirdSprite.Location;
			float Y_T = P.Y;
			float Y_B = P.Y + FlappyBirdSprite.Size.Height;
			float X_L = P.X;
			float X_R = P.X + FlappyBirdSprite.Size.Width;

			if ((X_R < X1_L && X_R < X1_R) || (X1_R < X_L && X1_L < X_L)) return false;
			else if ((Y1 < Y_T) && (Y_B < Y2)) return false;
			return true;
		}

		private bool CheckBirdCollisionWithCoin()
		{
			Point birdLocation = FlappyBirdSprite.Location;
			Point coinLocation = coin.Location;

			float X_Right = birdLocation.X + FlappyBirdSprite.Size.Width;
			float X_Left = birdLocation.X;
			float X_Right_Coin = coinLocation.X + coin.Size.Width;
			float X_Left_Coin = coinLocation.X;

			float Y_Top = birdLocation.Y;
			float Y_Bot = birdLocation.Y + FlappyBirdSprite.Size.Height;
			float Y_Bot_Coin = coinLocation.Y + coin.Size.Width;
			float Y_Top_Coin = coinLocation.Y;

			if ((X_Left_Coin <= X_Left && X_Left <= X_Right_Coin) || (X_Left_Coin <= X_Right && X_Right <= X_Right_Coin))
				if ((Y_Top_Coin <= Y_Top && Y_Top <= Y_Bot_Coin) || (Y_Top_Coin <= Y_Bot && Y_Bot <= Y_Bot_Coin))
				{
					/*SoundPlayer player = new SoundPlayer(path_coin_sound);
					player.Play();*/
					return true;
				}

			return false;
		}

		private void HighScores()
		{
			List<int> highscore = new List<int>();
			string path = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\FlappyBirdProject\HighScores.txt";

			using (StreamReader sr = File.OpenText(path))
			{
				string s = "";
				while ((s = sr.ReadLine()) != null)
				{
					int sInt = int.Parse(s);
					highscore.Add(sInt);
				}
			}

			highscore.Add(Score);
			highscore.Sort();
			highscore.Reverse();

			highscore = highscore.GetRange(0, 8);

			/*string r = "";

			foreach (int s in highscore)
			{
				r = r.Insert(r.Length, s.ToString() + " ");
			}

			MessageBox.Show(r);*/

			File.WriteAllText(path, string.Empty);

			using (StreamWriter sw = File.AppendText(path))
			{

				foreach (int s in highscore)
				{
					sw.WriteLine(s.ToString());
				}
			}

		}

		private void GameOver()
		{
			SoundPlayer player = new SoundPlayer(path_die_sound);
			player.Play();

			GravityTimer.Stop();
			dead = true;
			gravity = 0;

			HighScores();

			ScoreWindow window = new ScoreWindow(Score);
			window.Show();

			this.Close();
		}

		private void PipeTimer_Work(object sender, DoWorkEventArgs e)
		{
			while (!dead)
			{
				if (!pipesBehind)
				{
					/// move them..
					Point p = pipeBot.Location;
					p.X += pipeSpeed;
					pipeBot.Location = p;

					p = pipeTop.Location;
					p.X += pipeSpeed;
					pipeTop.Location = p;

					p = coin.Location;
					p.X += pipeSpeed;
					coin.Location = p;

					X_pipes = pipeTop.Location.X;
					UpdatePipes();
				}
				else RespawnPipes();

				System.Threading.Thread.Sleep(60);
			}
		}

		private void SpawnPipes()
		{
			pipeTop = TopPipe;
			pipeTop.Visible = true;
			pipeBot = BottomPipe;
			pipeBot.Visible = true;
			coin = Coin; // i am borrowing the properties of the coin picturebox
			coin.Visible = true;

			X_pipes = pipeTop.Location.X + pipeTop.Size.Width;

			this.Controls.Add(pipeTop);
			this.Controls.Add(coin);
			this.Controls.Add(pipeBot);

			PipeTimer.RunWorkerAsync();
		}

		private void FlappyBirdForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ' && !dead)
			{
				SoundPlayer player = new SoundPlayer(path_jump_sound);
				player.Play();

				miliseconds = 0;
				GravityTimer.Stop();
				JumpTimer.Start();
			}
		}

		private void UpdatePipes()
		{
			if (X_pipes <= -50)
				pipesBehind = true;
		}

		private void RespawnPipes()
		{
			pipesBehind = false;

			this.Controls.Remove(pipeTop);
			this.Controls.Remove(pipeBot);

			Random r = new Random();
			deltaHeight = r.Next(-120, 70);

			pipeTop.Location = new Point(300, -111 + deltaHeight);
			pipeBot.Location = new Point(300, 290 + deltaHeight);
			coin.Location = new Point(300, 207 + deltaHeight);

			gotCoin = false;

			this.Controls.Add(pipeTop);
			this.Controls.Add(pipeBot);
			this.Controls.Add(coin);
		}

		private void GravityTimer_Tick(object sender, EventArgs e)
		{
			if (!dead)
			{
				Point p = FlappyBirdSprite.Location;

				// checking if the bird hit the ground
				float Y_bottom_bird = p.Y + FlappyBirdSprite.Size.Height;
				Point p1 = Ground.Location;
				float Y_top_ground = p1.Y;



				if (Y_bottom_bird >= Y_top_ground && !dead) GameOver();
				else if (CheckBirdCollisionWithPipes() && !dead) GameOver();
				else
				{
					// fall down
					p = FlappyBirdSprite.Location;
					p.Y += gravity;
					FlappyBirdSprite.Location = p;

					if (CheckBirdCollisionWithCoin() && !gotCoin)
					{
						gotCoin = true;
						this.Controls.Remove(coin);
						Score++;
						Score_Label.Text = "Score: " + Score.ToString();
						// I should also play a sound, but we will implement it later.
					}
				}
			}
		}

		private void JumpTimer_Tick(object sender, EventArgs e)
		{
			if (CheckBirdCollisionWithPipes() && !dead) GameOver();

			if (miliseconds == 50) FlappyBirdSprite.Image = frame1;

			if (CheckBirdCollisionWithCoin() && !gotCoin)
			{
				gotCoin = true;
				this.Controls.Remove(coin);
				Score++;
				Score_Label.Text = "Score: " + Score.ToString();
				// I should also play a sound, but we will implement it later.
			}

			if (miliseconds < 100)
			{
				miliseconds += JumpTimer.Interval;
				Point p = FlappyBirdSprite.Location;
				p.Y += jumpSpeed;
				FlappyBirdSprite.Location = p;
			}
			else
			{
				JumpTimer.Stop();
				JumpAnimationWaitTimer.Start();
				FlappyBirdSprite.Image = frame2;
			}
		}

		private void JumpAnimationWaitTimer_Tick(object sender, EventArgs e)
		{
			if (CheckBirdCollisionWithPipes() && !dead) GameOver();

			if (CheckBirdCollisionWithCoin() && !gotCoin)
			{
				gotCoin = true;
				this.Controls.Remove(coin);
				Score++;
				Score_Label.Text = "Score: " + Score.ToString();
				// I should also play a sound, but we will implement it later.
			}

			if (miliseconds < 140)
			{
				miliseconds += JumpAnimationWaitTimer.Interval;
			}
			else
			{
				JumpAnimationWaitTimer.Stop();
				GravityTimer.Start();
				FlappyBirdSprite.Image = frame3;
			}
		}
	}
}
