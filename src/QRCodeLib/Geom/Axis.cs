using QRCodeImageReader = ThoughtWorks.QRCode.Codec.Reader.QRCodeImageReader;
namespace ThoughtWorks.QRCode.Geom
{
    /// <summary> This class designed to move target point based on independent axis.
    /// It allows move target coodinate on rotated, scaled and gauche QR Code image
    /// </summary>
    public class Axis
	{

        internal int sin, cos;
        internal int modulePitch;
        internal Point origin;

        public virtual Point Origin
		{
			set
			{
				origin = value;
			}
			
		}
		public virtual int ModulePitch
		{
			set
			{
				modulePitch = value;
			}
			
		}
		
		public Axis(int[] angle, int modulePitch)
		{
			sin = angle[0];
			cos = angle[1];
			this.modulePitch = modulePitch;
			origin = new Point();
		}
		
		public virtual Point translate(Point offset)
		{
			int moveX = offset.X;
			int moveY = offset.Y;
			return translate(moveX, moveY);
		}
		
		public virtual Point translate(Point origin, Point offset)
		{
			Origin = origin;
			int moveX = offset.X;
			int moveY = offset.Y;
			return translate(moveX, moveY);
		}
		
		public virtual Point translate(Point origin, int moveX, int moveY)
		{
			Origin = origin;
			return translate(moveX, moveY);
		}
		
		public virtual Point translate(Point origin, int modulePitch, int moveX, int moveY)
		{
			Origin = origin;
			this.modulePitch = modulePitch;
			return translate(moveX, moveY);
		}
	
		public virtual Point translate(int moveX, int moveY)
		{
			long dp = QRCodeImageReader.DECIMAL_POINT;
			Point point = new Point();
			int dx = (moveX == 0)?0:(modulePitch * moveX) >> (int) dp;
			int dy = (moveY == 0)?0:(modulePitch * moveY) >> (int) dp;
			point.translate((dx * cos - dy * sin) >> (int) dp, (dx * sin + dy * cos) >> (int) dp);
			point.translate(origin.X, origin.Y);
			return point;
		}
	}
}