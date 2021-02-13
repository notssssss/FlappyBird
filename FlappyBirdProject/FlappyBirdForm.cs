using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdProject
{
	public partial class FlappyBirdForm : Form
	{
		private int gravity = 2;
		public FlappyBirdForm()
		{
			InitializeComponent();
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Point p = FlappyBirdSprite.Location;
			p.Y += gravity;
			FlappyBirdSprite.Location = p;
		}
	}
}
