using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk2HarryVashisht
{
	class DeskQuote 
	{
		private const double BASE_PRICE = 200.00;
		private double surfaceMaterialCost;
		private double surfaceAreaCost;
		private double drawerCost;
		private double rushOrderCost = 0.00;
		private double totalCost;

		public DateTime Date { get; set; }
		public string Name { get; set; }
		public int ShippingDays { get; set; }
		public Desk desk = new Desk();

		public double CalculateDrawerCost()
		{
			drawerCost = desk.NumDrawers * 50.00;
			return drawerCost;
		}

		public double CalculateSurfaceAreaCost()
		{
			surfaceAreaCost = desk.SurfaceArea * 1.00;
			return surfaceAreaCost;
		}

		public double CalculateRushOrderCost()
		{
			if (ShippingDays == 3)
			{
				if (desk.SurfaceArea < 1000)
					rushOrderCost = 60.00;
				else if (desk.SurfaceArea < 2000)
					rushOrderCost = 70.00;
				else
					rushOrderCost = 80.00;
			}
			else if (ShippingDays == 5)
			{
				if (desk.SurfaceArea < 1000)
					rushOrderCost = 40.00;
				else if (desk.SurfaceArea < 2000)
					rushOrderCost = 50.00;
				else
					rushOrderCost = 60.00;
			}
			else if (ShippingDays == 7)
			{
				if (desk.SurfaceArea < 1000)
					rushOrderCost = 30.00;
				else if (desk.SurfaceArea < 2000)
					rushOrderCost = 35.00;
				else
					rushOrderCost = 40.00;
			}
			else
			{
				rushOrderCost = 0.00;
			}

			return rushOrderCost;
		}

		public double CalculateSurfaceMaterialCost()
		{
			switch (desk.Material)
			{
				case Desk.SurfaceMaterial.laminate:
					surfaceMaterialCost = 100.00;
					break;
				case Desk.SurfaceMaterial.oak:
					surfaceMaterialCost = 200.00;
					break;
				case Desk.SurfaceMaterial.pine:
					surfaceMaterialCost = 50.00;
					break;
				case Desk.SurfaceMaterial.rosewood:
					surfaceMaterialCost = 300.00;
					break;
				case Desk.SurfaceMaterial.veneer:
					surfaceMaterialCost = 125.00;
					break;
			}
			return surfaceMaterialCost;
		}

		public double CalculateTotalCost()
		{
			totalCost = BASE_PRICE + rushOrderCost + 
				surfaceMaterialCost + surfaceAreaCost + drawerCost;
			return totalCost;
		}
	}
}
