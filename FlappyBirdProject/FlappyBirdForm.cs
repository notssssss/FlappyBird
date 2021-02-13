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
		public FlappyBirdForm()
		{
			InitializeComponent();
			GravityTimer.Start();
			JumpTimer.Start();
		}

		private void GravityTimer_Tick(object sender, EventArgs e)
		{
			Point p = FlappyBirdSprite.Location;
			p.Y += gravity;
			FlappyBirdSprite.Location = p;
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				milliseconds = 0;
				SoundPlayer player = new SoundPlayer(@"C:\Users\Soumya\Desktop\Repositories\FlappyBird\SoundEffects\wing.wav");
				player.Play();
				GravityTimer.Stop();
				JumpTimer.Start();
			}
		}

		private void JumpTimer_Tick(object sender, EventArgs e)
		{
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
			}
		}

		private void JumpAnimationWait_Tick(object sender, EventArgs e)
		{
			if (milliseconds < 130)
			{
				milliseconds += JumpAnimationWaitTimer.Interval;
			}
			else
			{
				JumpAnimationWaitTimer.Stop();
				GravityTimer.Start();
			}
		}
	}
}
