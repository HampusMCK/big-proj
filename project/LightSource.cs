using System.Numerics;
using Raylib_cs;

public class LightSource
{
    public Vector2 position;
    public float strength;
    public float spread;

    public void shineLight(Rectangle player){
        Raylib.DrawRectangle((int)this.position.X - 50, (int)this.position.Y - 30, 100, 30, Color.LightGray);
        Raylib.DrawRectangle((int)this.position.X - 35, (int)this.position.Y - 50, 70, 20, Color.LightGray);
        Raylib.DrawRectangle((int)this.position.X - 10, (int)this.position.Y - 80, 20, 30, Color.LightGray);
        Raylib.DrawRectangle((int)this.position.X - 150, (int)this.position.Y - 80, 160, 20, Color.LightGray);
        Raylib.DrawRectangle((int)this.position.X - 150, (int)this.position.Y - 80, 20, 580, Color.LightGray);
        
        Raylib.DrawTriangle(this.position, new Vector2(this.position.X - (this.strength * this.spread), this.position.Y + this.strength), new Vector2(this.position.X + (this.strength * this.spread), this.position.Y + this.strength), new Color(255, 255, 0, 150));
        
        if (Raylib.CheckCollisionPointTriangle(new Vector2(player.Position.X + 100, player.Position.Y), this.position, new Vector2(this.position.X - (this.strength * this.spread), this.position.Y + this.strength), new Vector2(this.position.X + (this.strength * this.spread), this.position.Y + this.strength)))
        {
            float yValue = player.Position.Y;
            float xValue = this.position.X - ((yValue - this.position.Y) * this.spread);
            if (player.Position.X < xValue)
            {
                Raylib.DrawTriangle(new Vector2(xValue, yValue), new Vector2(xValue - (this.spread * 100), yValue + 100), new Vector2(xValue, yValue + 100), new Color(0, 0, 0, 150));
            }
            else
            {
                Vector2 dir = player.Position - this.position;
                dir = Vector2.Normalize(dir);
                Raylib.DrawTriangle(player.Position, new Vector2(player.Position.X + (dir.X * 100), player.Position.Y + 100), new Vector2(player.Position.X, player.Position.Y + 100), new Color(0, 0, 0, 150));
            }
        }

        if (Raylib.CheckCollisionPointTriangle(player.Position, this.position, new Vector2(this.position.X - (this.strength * this.spread), this.position.Y + this.strength), new Vector2(this.position.X + (this.strength * this.spread), this.position.Y + this.strength)))
        {
            float yValue = player.Position.Y;
            float xValue = this.position.X + ((yValue - this.position.Y) * this.spread);
            if (player.Position.X + 100 > xValue)
            {
                Raylib.DrawTriangle(new Vector2(xValue, yValue), new Vector2(xValue, yValue + 100), new Vector2(xValue + (this.spread * 100), yValue + 100), new Color(0, 0, 0, 150));
            }
            else
            {
                Vector2 dir = new Vector2(player.Position.X + 100, player.Position.Y) - this.position;
                dir = Vector2.Normalize(dir);
                Raylib.DrawTriangle(new Vector2(player.Position.X + 100, player.Position.Y), new Vector2(player.Position.X + 100, player.Position.Y + 100), new Vector2(player.Position.X + 100 + (dir.X * 100), player.Position.Y + 100), new Color(0, 0, 0, 150));
            }
        }
    }
}