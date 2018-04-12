using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2HarryVashisht
{
	class Desk
	{		
		public int Width { get; set; }

		public int Depth { get; set; }

		public int SurfaceArea { get { return Width * Depth; } }

		public int NumDrawers { get; set; }

		public enum SurfaceMaterial
		{
			laminate,
			oak,
			rosewood,
			veneer,
			pine
		};

		public SurfaceMaterial Material { get; set; }
	}
}
