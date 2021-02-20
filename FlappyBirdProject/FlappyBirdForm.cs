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
		private int gravity = 2;
		private int jumpspeed = -4;
		private int milliseconds = 0;

		private Image frame1, frame2, frame3;
		public FlappyBirdForm()
		{
			InitializeComponent();
			frame1 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_0.png");
			frame2 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_1.png");
			frame3 = Image.FromFile(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\Sprites\FB_2.png");
			GravityTimer.Start();
			JumpTimer.Start();
		}

		private void Jump()
		{
			milliseconds = 0;
			SoundPlayer player = new SoundPlayer(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\wing.wav");
			player.Play();
			GravityTimer.Stop();
			JumpTimer.Start();
		}
		private void GravityTimer_Tick(object sender, EventArgs e)
		{
			Point p = FlappyBirdSprite.Location;
			p.Y += gravity;
			FlappyBirdSprite.Location = p;
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
			if (e.KeyChar == ' ')
			{
				Jump();
			}
		}
	}
}
