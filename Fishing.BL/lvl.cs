using Fishing.BL; 
using Fishing.BL.Model.Waters; 
using System; 
using System.Collections.Generic; 
using WindowsFormsApp1; 
using System.Drawing; 
using Fishing.BL.Resources.Images;
[Serializable] 
public class kgkg : Water 
{ 
private static kgkg water; 
private kgkg() : base("LocName",Images.MesheraMap, 1200, 1600,new List<PicturesBoxInfo>())
{
}
 public static kgkg GetWater()
{
 if (water == null)
{
 water = new kgkg();
}
 return water;
}
}