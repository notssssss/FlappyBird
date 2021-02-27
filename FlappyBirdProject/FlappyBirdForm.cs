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

namespace FlappyBirdProject
{
	public partial class FlappyBirdForm : Form
	{
		private int gravity = 3;
		private int jumpspeed = -6;
		private int milliseconds = 0;
		private int pipespeed = -14;

		private Image frame1, frame2, frame3;

		private string path_die_sound = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\hit.wav";
		private string path_jump_sound = @"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\wing.wav";

		private bool dead = false;

		private PictureBox pipeTop;
		private PictureBox pipeBot;

		private BackgroundWorker PipeTimer = new BackgroundWorker();
		public FlappyBirdForm()
		{
			InitializeComponent();
			frame1 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_0.png");
			frame2 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_1.png");
			frame3 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_2.png");
			GravityTimer.Start();
			JumpTimer.Start();

			PipeTimer.DoWork += new DoWorkEventHandler(PipeTimer_Work);

			SpawnPipes();
		}

		private void PipeTimer_Work(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				Point p = pipeBot.Location;
				p.X += pipespeed;
				pipeBot.Location = p;

				p = pipeTop.Location;
				p.X += pipespeed;
				pipeTop.Location = p;
				System.Threading.Thread.Sleep(100); // Wait five minutes
			}
		}
		private void Jump()
		{
			milliseconds = 0;
			SoundPlayer player = new SoundPlayer(path_jump_sound);
			player.Play();
			GravityTimer.Stop();
			JumpTimer.Start();
		}

		private void GameOver()
		{
			SoundPlayer player = new SoundPlayer(path_die_sound);
			player.Play();

			GravityTimer.Stop();
			dead = true;
			gravity = 0;
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
				}
			}
		}

		private void JumpTimer_Tick(object sender, EventArgs e)
		{
			if (CheckBirdCollisionWithPipes() && !dead) GameOver();
			if (milliseconds == 50) FlappyBirdSprite.Image = frame1;

			if (milliseconds < 100)
			{
				milliseconds += JumpTimer.Interval;
				Point p = FlappyBirdSprite.Location;
				p.Y += jumpspeed;
				FlappyBirdSprite.Location = p;
			}
			else
			{
				JumpTimer.Stop();
				JumpAnimationWaitTimer.Start();
				FlappyBirdSprite.Image = frame2;
			}
		}

		private void SpawnPipes()
		{
			pipeTop = TopPipe;
			pipeTop.Visible = true;
			pipeBot = BottomPipe;
			pipeBot.Visible = true;

			this.Controls.Add(pipeTop);
			this.Controls.Add(pipeBot);

			PipeTimer.RunWorkerAsync();
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

		private void JumpAnimationWaitTimer_Tick(object sender, EventArgs e)
		{
			if (CheckBirdCollisionWithPipes() && !dead) GameOver();

			if (milliseconds < 130)
			{
				milliseconds += JumpAnimationWaitTimer.Interval;
				FlappyBirdSprite.Image = frame3;
			}
			else
			{
				JumpAnimationWaitTimer.Stop();
				GravityTimer.Start();
				FlappyBirdSprite.Image = frame3;
			}
		}

		private void FlappyBirdForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ' && !dead)
			{
				Jump();
			}
		}
	}
}
