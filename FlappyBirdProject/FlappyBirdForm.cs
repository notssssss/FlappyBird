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
		private void GravityTimer_Tick(object sender, EventArgs e)
		{
			if (!dead)
			{
				Point p = FlappyBirdSprite.Location;

				// checking if the bird hit the ground
				float Y_bottom_bird = p.Y + FlappyBirdSprite.Size.Height;
				Point p1 = Ground.Location;
				float Y_top_ground = p1.Y;

				if (Y_bottom_bird >= Y_top_ground && !dead)
				{
					SoundPlayer player = new SoundPlayer(path_die_sound);
					player.Play();

					GravityTimer.Stop();
					MessageBox.Show("Dead bird. :-(");
					dead = true;
					gravity = 0;
				}
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

		private void JumpAnimationWaitTimer_Tick(object sender, EventArgs e)
		{
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
