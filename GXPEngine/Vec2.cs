using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(float k, Vec2 right)
	{
		return new Vec2(k * right.x, k * right.y);
	}

	public static Vec2 operator *(Vec2 left, float k)
	{
		return new Vec2(k * left.x, k * left.y);
	}

	public float Length()
	{
		return Mathf.Sqrt(x * x + y * y);
	}

	public Vec2 Normalized()
	{
		float l = Length();
		if (l != 0)
		{
			return new Vec2(x / l, y / l);
		}
		else return this;

	}

	public void Normalize()
	{
		float l = Length();
		if (l != 0)
		{
			y /= l;
			x /= l;
		}
	}

	public void SetXY(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}

	public static float Deg2Rad(float deg)
	{
		float rad = deg * Mathf.PI / 180.0f;
		return rad;
	}

	public static float Rad2Deg(float rad)
	{
		float deg = rad * 180 / Mathf.PI;
		return deg;
	}

	public static Vec2 GetUnitVectorDeg(float deg)
	{
		float rad = Deg2Rad(deg);
		return GetUnitVectorRad(rad);
	}

	public static Vec2 GetUnitVectorRad(float rad)
	{
		float x = Mathf.Cos(rad);
		float y = Mathf.Sin(rad);
		return new Vec2(x, y);
	}

	public static Vec2 RandomUnitVector()
	{
		float random = Utils.Random(0, 360);
		//Console.WriteLine("Degrees: " + random);
		return GetUnitVectorDeg(random);
	}

	public void SetAngleDegrees(float direction)
	{
		SetAngleRadians(Deg2Rad(direction));
	}

	public void SetAngleRadians(float direction)
	{
		//Console.WriteLine("Original length: " + Length());
		float l = Length();
		Vec2 v1 = GetUnitVectorRad(direction);
		SetXY(v1.x * l, v1.y * l);
		//Console.WriteLine("SetAngle length: " + Length());
	}

	public float GetAngleRadians()
	{
		return Mathf.Atan2(y, x);
	}

	public float GetAngleDegrees()
	{
		return Rad2Deg(GetAngleRadians());
	}

	public void RotateDegrees(float angle)
	{
		RotateRadians(Deg2Rad(angle));
	}

	public void RotateRadians(float angle)
	{
		float cos = Mathf.Cos(angle);
		float sin = Mathf.Sin(angle);
		SetXY((x * cos - y * sin), (x * sin + y * cos));
	}

	public void RotateAroundDegrees(Vec2 point, float angle)
	{
		RotateAroundRadians(point, Deg2Rad(angle));
	}

	public void RotateAroundRadians(Vec2 point, float angle)
	{
		SetXY(x - point.x, y - point.y);
		RotateRadians(angle);
		SetXY(x + point.x, y + point.y);
	}

	public float Dot(Vec2 b)
	{
		//Console.WriteLine(x * b.x + y * b.y);
		return x * b.x + y * b.y;
	}

	public Vec2 Normal()
	{
		Vec2 normal = new Vec2(-y, x);
		normal.Normalize();
		return normal;
	}

	public void Reflect(Vec2 pNormal, float pBounciness = 1)
	{
		this -= (1 + pBounciness) * Dot(pNormal) * pNormal;
	}
}